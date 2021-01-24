    public static IUnityContainer RegisterMvcComponents(this IUnityContainer container) {
        var lifetimeManager = new HierarchicalLifetimeManager();
        container.RegisterType<IHttpContextAccessor, HttpContextProvider>(lifetimeManager);
        return container;
    }
    
