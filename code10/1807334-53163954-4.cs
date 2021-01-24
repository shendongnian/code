    public void ConfigureServices(IServiceCollection services) {
        var settings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
        services.AddTransient<DatabaseSettings>(_ => settings);    
        services.AddTransient<IConnectionOption, Class1>();
    }
