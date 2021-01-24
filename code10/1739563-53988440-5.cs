    public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);//Autofac.Extensions.DependencyInjection
             
            /*Here we are going to register services for DI*/
           
            return new AutofacServiceProvider(builder.Build());
        }
