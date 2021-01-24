    public static void Configure()
    {
        var container = new UnityContainer();
        RegisterDepedencies(container);
        container.AddExtension(new FactoryFallbackExtension());
        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        SetControllerFactory(container);
    }
