    public static class Program
    {
      public static int Main()
      {
        var configuration = new ConfigurationBuilder()
          .AddConfiguration()
          .Build();
    
        // setup Serilog logging
        Log.Logger = new LoggerConfiguration()
          .ReadFrom.Configuration(configuration)
          .CreateLogger();
    
        // Code removed for brevity...
      }
    
      private static IWebHost BuildWebHost() =>
        WebHost.CreateDefaultBuilder()
          .UseSerilog()
          .UseStartup<Startup>()
          .ConfigureAppConfiguration((hostingContext, config) =>
          {
            // Clear default configuration
            config.Sources.Clear();
    
            // Replace with our own configuration
            config.AddConfiguration();
          })
          .Build();
    
      private static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder self) =>
        self
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
          .AddJsonFile($"appsettings.{envName}.json", optional:true, reloadOnChange:true)
          .AddEnvironmentVariables();
    }
