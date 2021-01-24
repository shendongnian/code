       public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMokaKukaTrackerDbContext(CurrentEnvironment, Configuration);
    
            return new AutofacServiceProvider(CreateIoCContainer(services));
        }
    
        private static IContainer CreateIoCContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new AutofacInjectorBootstrapperModule());
            builder.RegisterModule(new AutofacEventHandlingBootstrapperModule());
    
            return builder.Build();
        }
