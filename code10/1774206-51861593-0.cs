    public static void RegisterTypes(IUnityContainer container)
    {
        var resolver = new PerRequestLifetimeManager();
        container.RegisterType<OITTimeSheetDBContextFactory>(resolver);
        container.RegisterType<UserContext>(resolver);
    }
