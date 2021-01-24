    public SvcPool(IOptions<AppConfig> config, ILogger<SvcPool> logger, ILoggerFactory loggerFactory)
    {
        foreach (var svcConfig in config.Value.SvcList)
        {
            Svc svc = new Svc(svcConfig.ID, svcConfig.Host, loggerFactory.CreateLogger<Svc>());
        }
    }
