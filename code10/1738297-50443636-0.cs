        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMokaKukaTrackerDbContext(CurrentEnvironment, Configuration);
            services.RegisterIdentityFramework();
            services.AddAndConfigureMvc(CurrentEnvironment);
    
            var container = CreateIoCContainer(services);
            var autofacServiceProvider = new AutofacServiceProvider(container);
            DomainEvents.Init(container);
    
            return autofacServiceProvider;
        }
