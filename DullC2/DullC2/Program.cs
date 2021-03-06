using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DullC2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TeamServer.Controllers;

namespace TeamServer
{
    public class Program
    {
        public static ServerController ServerController { get; private set; }

        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("No server password provided");
                return;
            }

            AuthenticationController.SetPassword(args[0]);

            ServerController = new ServerController();
            // do more setup here
            //ServerController.Start();



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
