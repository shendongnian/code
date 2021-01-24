    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging => { logging.ClearProviders(); }) // clearing all other logging providers
                    .UseSerilog(); // Using serilog
 
