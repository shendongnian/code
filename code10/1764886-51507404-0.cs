    var serviceProvider = new ServiceCollection()
            .AddSingleton<ILoggerFactory, LoggerFactory>()
            .AddSingleton(typeof(ILogger<>), typeof(Logger<>))
            .AddConsole(LogLevel.Debug)
            .BuildServiceProvider();
    
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    
    var enabled = logger.IsEnabled(LogLevel.Debug);
    logger.LogDebug("Starting application");
