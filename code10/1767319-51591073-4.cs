    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddLogging();
    
        services.AddSingleton<IConfiguration>(Configuration);
        services.AddSingleton<IDbFactory, DefaultDbFactory>();
        services.AddSingleton<IUserRepository, UserRepository>();    
        services.AddSingleton<IEmailService, EmailService>();          
        services.AddSingleton<IHostedService, BackgroundService>();
        services.AddSingleton<ISettingsRepository, SettingsRepository>();
        services.AddSingleton(typeof(TokenManager));
    
        // var sp = services.BuildServiceProvider(); // NO NEED for this after all
        // var userRepository = sp.GetService<IUserRepository>();
    
        services.AddMvc(); // No config options required any more
        services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptions>();  // Here be the magic...
    
        // ...
    }
