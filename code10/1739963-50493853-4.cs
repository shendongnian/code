            var unityContainer = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
            unityContainer.RegisterType<IServiceLocator, UnityServiceLocator>(new ContainerControlledLifetimeManager());
            // automapper
            var config = new MapperConfiguration(cfg =>
               cfg.AddProfile(new AutoMapperBootstrap())
           );
            unityContainer.RegisterType<IMapper>(new InjectionFactory(_ => config.CreateMapper()));
            // factories
            unityContainer.RegisterType<IWelcomeGateViewFactory, WelcomeGateViewFactory>();
            unityContainer.RegisterType<ITrailerPictureViewFactory, TrailerPictureViewFactory>();
            // services
            unityContainer.RegisterType<IDataService, OfflineDataService>("OfflineDataService", new ContainerControlledLifetimeManager(), new InjectionConstructor(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ServiceLocator.Current.GetInstance<IMapper>()));
            unityContainer.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ITestDataService, TestDataService>(new ContainerControlledLifetimeManager()); 
            ...
