    var serviceProvider = new ServiceCollection()
            .AddSingleton<ILoggerFactory, LoggerFactory>()
            .AddSingleton(typeof(ILogger<>), typeof(Logger<>))            
            .BuildServiceProvider();
    var factory = serviceProvider.GetRequiredService<ILoggerFactory>();
    factory.AddConsole(LogLevel.Debug);
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    
    var enabled = logger.IsEnabled(LogLevel.Debug);
    logger.LogDebug("Starting application");
