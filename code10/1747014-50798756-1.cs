    public static void ConfigureUnityContainer(IUnityContainer container)
    {
        // some other resgistration
        container.RegisterType<MyEntities>(new PerRequestLifetimeManager());
    }
