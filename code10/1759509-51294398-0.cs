    public static IServiceCollection RegisterAutomapperConfiguration(this IServiceCollection services, 
        ServiceLifetime lifeTime = ServiceLifetime.Scoped) {
           
        services.Register<IAutomapperProvider>(p => //<-- p is IServiceProvider
             //use the provider to get the IAssemblyProvider for my IAutomapperProvider
            new AutomapperProvider(p.GetService<IAssemblyProvider>()), lifeTime);
        prov = services.BuildServiceProvider();
        var autoMapperProvider = prov.GetService<IAutomapperProvider>();
        var mapperConfig = autoMapperProvider.GetMapperConfiguration();
        //...
    }
