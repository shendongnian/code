    public void ConfigureServices(IServiceCollection services) {
        services.AddTransient<IAppSettings, AppSettings>();
        services.AddTransient<IDbConnectionFactory, MyDbConnectionFactory>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddMvc();
    }
