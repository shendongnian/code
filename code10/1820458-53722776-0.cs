     public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConsole();
                    logging.AddFilter(null, LogLevel.Warning);
                })
                .UseStartup<Startup>()
                .ConfigureLogging(logging => logging.AddFilter("Microsoft", LogLevel.Warning));
