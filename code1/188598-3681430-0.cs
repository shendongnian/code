    public void Register(IUnityContainer container)
    {
       container.RegisterType<IOutputCacheVaryByCustom,OutputCacheVaryByIsAuthenticated>("auth");
       container.RegisterType<IOutputCacheVaryByCustom,OutputCacheVaryByRoles>("roles");
    }
