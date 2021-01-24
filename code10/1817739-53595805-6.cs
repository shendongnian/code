    public static async Task Main(string[] args)
    {  
        var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
            // i needed the input argument for command line, you can use it or simply remove this block
                config.AddEnvironmentVariables();
    
                if (args != null)
                {
                    config.AddCommandLine(args);
                }
    
                Shared.Configuration = config.Build();
            })
            .ConfigureServices((hostContext, services) =>
            {
                // dependency injection
          
                services.AddOptions();
               // here is the core, where you inject the
               services.AddSingleton<Daemon>();
               services.AddSingleton<IHostedService, MyService>();
            })
            .ConfigureLogging((hostingContext, logging) => {
               // console logging 
			    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
            });
    
        await builder.RunConsoleAsync();
    }
