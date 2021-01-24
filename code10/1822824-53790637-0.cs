    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<LoggingService>();
        services.AddMvc();
    }
