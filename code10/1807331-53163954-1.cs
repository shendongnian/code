    public void ConfigureServices(IServiceCollection services) {
        var settings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
        services.AddTransient<DatabaseSettings>(settings);    
        services.AddTransient<IConnectionOption, Class1>();
    }
