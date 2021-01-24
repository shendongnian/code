    public static IUnityContainer RegisterMvcComponents(this IUnityContainer container) {
        var lifetimeManager = new HierarchicalLifetimeManager();
        container.RegisterInstance<IHttpContextAccessor>(
            new HttpContextProvider(), lifetimeManager);
        return container;
    }
    
