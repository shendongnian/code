    using Microsoft.AspNetCore.Hosting;
    using Serilog;
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog.Core;
    
    namespace My.App
    {
        public class Program
        {
            private static bool IsDevelopment =>
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    
            public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .AddEnvironmentVariables()
                .Build();
    
            public static Logger Logger { get; } = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
    
            public static int Main(string[] args)
            {
                Log.Logger = Logger;
    
                try
                {
                    Log.Information("Starting...");
                    var host = CreateHostBuilder(args).Build();
    
                    var migrationStatus = RunDatabaseMigration(host);
                    
                    host.Run();
    
                    Log.Information("Started Successfully");
                    
                    return 0;
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Host terminated unexpectedly");
                    return 1;
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
    
            public static IHostBuilder CreateHostBuilder(string[] args)
            {
                var host = Host.CreateDefaultBuilder(args)
                    .UseSerilog()
                    .UseServiceProviderFactory(
                        new AutofacMultitenantServiceProviderFactory(Startup.ConfigureMultitenantContainer))
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseIISIntegration()
                            .UseStartup<Startup>();
                    });
    
                return host;
            }
        }
    }
