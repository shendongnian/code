    services.AddTransient<IMyLogRepository, LogRepository>();
    var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole()
                       .AddDbLoggerProvider(services.BuildServiceProvider().GetService<IMyLogRepository>());
            });
            services.AddSingleton(loggerFactory.CreateLogger("MyLogging"));
