    private static IUnityContainer container = null;
    private static IUnityContainer CreateContainer()
    {
        if( container == null )
        {
            container = new UnityContainer();
            container.RegisterType<IConfigurationService, ConfigFile>();
            container.RegisterType<ILoggerService, NlogLoggerService>();
    
            container.RegisterInstance<ISearchService>(
                new LuceneSearchService(
                    container.Resolve<IConfigurationService>(),
                    container.Resolve<ILoggerService>()),
                    new ContainerControlledLifetimeManager());
        }
    
        return container;
    }
