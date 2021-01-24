    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        // ...
        IdentityRegistrar.Register(services);                  // No change
        AuthConfigurer.Configure(services, _appConfiguration); // No change
        services.ConfigureApplicationCookie(o =>
        {
            o.ExpireTimeSpan = TimeSpan.FromHours(1);
            o.SlidingExpiration = true;
        });
        // ...
    }
