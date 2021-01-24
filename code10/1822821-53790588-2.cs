    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IHostingEnvironment>(env);
        services.AddScoped<ILoggingService, LoggingService>();
    }
