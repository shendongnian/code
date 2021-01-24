    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddLogging();
        var sp = services.BuildServiceProvider(); // Build service provider *before* registering services
        services.AddSingleton<IConfiguration>(Configuration);
        services.AddSingleton<IDbFactory, DefaultDbFactory>();
        services.AddSingleton<IUserRepository, UserRepository>();  
        services.AddSingleton<IEmailService, EmailService>();          
        services.AddSingleton<IHostedService, BackgroundService>();
        services.AddSingleton<ISettingsRepository, SettingsRepository>();
        services.AddSingleton(typeof(TokenManager));
        var userRepository = sp.GetService<IUserRepository>();
        // ...
    }
