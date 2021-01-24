    ...
    public static ILogger<ConsoleLoggerProvider> AppLogger = null;
    public static ILoggerFactory loggerFactory = null;
    //
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(builder => builder
            .AddConsole()
            .AddFilter(level => level >= LogLevel.Trace)
        );
        loggerFactory = services.BuildServiceProvider().GetService<ILoggerFactory>();
        AppLogger = loggerFactory.CreateLogger<ConsoleLoggerProvider>();
        ...
