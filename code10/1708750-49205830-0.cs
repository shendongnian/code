    public static UnityContainer Register()
    {
        var container = new UnityContainer();
        // Register all types with Unity here
        container.RegisterType<IHostBufferPolicySelector, OwinBufferPolicySelector>();
        GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        return container;
    }
