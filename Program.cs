using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggingExample
{
    public class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Main(string[] args)
        {
             var logRepository = log4net.LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());

            //Load configuration from log4net.config file
            log4net
                .Config
                .XmlConfigurator
                .Configure(
                    logRepository,
                    new System.IO.FileInfo("log4net.config")
                );
            Console.WriteLine("Hello World!");

            log.Info("Log4net for .Net Core Hello World");
            
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
