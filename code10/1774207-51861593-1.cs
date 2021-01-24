    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<OITTimeSheetDBContextFactory>(new PerRequestLifetimeManager());
        container.RegisterType<UserContext>(new PerRequestLifetimeManager());
    }
