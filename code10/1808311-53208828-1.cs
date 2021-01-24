        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);
            // Add application services.
            // This creates an object dependency graph that is used to populate all constructor arguments using DI.
            BootstrapDependencyInjectionTree.Bootstrap(_container);
            // Web api only dependencies.
            _container.RegisterSingleton<IMonitorMetaDataProvider, MonitorMetaDataProvider>();
            // Allow Simple Injector to resolve services from ASP.NET Core.
            _container.AutoCrossWireAspNetComponents(app);
        }
