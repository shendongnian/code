    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<ILocationService, LocationService>()
            .AddSingleton(_ => BootStatus.Instantiate())
            .AddScoped<IClock>(_ => new ZonedClock(SystemClock.Instance, DateTimeZone.Utc, CalendarSystem.Iso))
            .AddHostedService<BootService>()
            .AddMvcCore()
            .AddDataAnnotations()
            .AddJsonFormatters()
            .AddApiExplorer()
            .AddAuthorization();
    
        /* Other code, not relevant here. */
    }
