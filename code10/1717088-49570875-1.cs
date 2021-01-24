    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddTransient<ISomething, Something>();
    }
