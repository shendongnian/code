    services.AddSingleton<Svc.Factory>(svcProvider => (id, host) => new Svc(id, host, svcProvider.GetRequiredService<ILogger<Svc>>()));
    public class Svc
    {
        public delegate Svc Factory(int id, string host);
        public Svc(int id, string host, ILogger<Svc> logger)
        {
        }
    }
    public SvcPool(IOptions<AppConfig> config, ILogger<SvcPool> logger, Svc.Factory serviceFactory)
    {
        foreach (var svcConfig in config.SvcList)
        {
            Svc svc = serviceFactory(svcConfig.ID, svcConfig.Host);
        }
    }
