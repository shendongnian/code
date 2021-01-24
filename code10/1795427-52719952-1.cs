       public void ConfigureServices(IServiceCollection services)
        {
         services.AddMvc();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
          container.RegisterModule(new ApplicationModule());
        }
