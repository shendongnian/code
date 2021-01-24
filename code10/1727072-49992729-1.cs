    private static IServiceProvider BuildDi() {
        var services = new ServiceCollection();
    
        services.AddTransient<Runner>();
        // Adds logging services to the service collection
        // If you don't explicitly set the minimum level, the default value is 
        // Information, which means that Trace and Debug logs are ignored.
        services.AddLogging();
    
        var serviceProvider = services.BuildServiceProvider();
    
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
    
        /// Enable NLog as logging provider in .NET Core.
        loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
        // Apply NLog configuration from XML config.
        loggerFactory.ConfigureNLog("nlog.config");
    
        return serviceProvider;
    }
