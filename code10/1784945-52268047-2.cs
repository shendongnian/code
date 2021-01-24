    services.AddSingleton<Func<ILogger<Svc>>(svcProvider => () => svcProvider.GetRequiredService<ILogger<Svc>>());
    public SvcPool(IOptions<AppConfig> config, ILogger<SvcPool> logger, Func<ILogger<Svc>> loggerFactory)
    {
        foreach (var svcConfig in config.SvcList)
        {
            Svc svc = new Svc(svcConfig.ID, svcConfig.Host, loggerFactory());
        } 
    }
