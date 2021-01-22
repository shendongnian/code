        private IUnityContainer container;
        private void InitializeUnity()
        {
            container = new UnityContainer();
            container.RegisterType<IHandler, Handler2>("Handler2",
                new InjectionConstructor(new ResolvedParameter<IDataContext>(), new ResolvedParameter<IHandler>("Handler1")));
            container.RegisterType<IHandler, Handler>("Handler1");
            container.RegisterType<IDataContext, DataContext>(new PerResolveLifetimeManager());
            container.RegisterType<IServiceClass, ServiceClass>("MyClass", new InjectionConstructor(new ResolvedParameter<IHandler>("Handler2")));
        }
        private void CallService()
        {
            var service = container.Resolve<ServiceClass>("MyClass");
            service.DoService();
            // Resolving and calling again to simulate multiple resolves:
            service = container.Resolve<ServiceClass>("MyClass");
            service.DoService();
        }
