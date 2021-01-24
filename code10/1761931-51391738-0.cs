     public static void ConfigureContainer()
            {
                var builder = new ContainerBuilder();
    
                // Get your HttpConfiguration.
                var config = GlobalConfiguration.Configuration;
    
                // Register your Web API controllers.
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    
                // OPTIONAL: Register the Autofac filter provider.
                builder.RegisterWebApiFilterProvider(config);
    
                // OPTIONAL: Register the Autofac model binder provider.
                builder.RegisterWebApiModelBinderProvider();
    
    
                builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest().WithParameter("connectionString", "DefaultConnectionString");
                builder.Register(c => new UnitOfWork(c.Resolve<ApplicationContext>())).AsImplementedInterfaces().InstancePerRequest();
                builder.RegisterType<OrderManager>().AsSelf().InstancePerRequest();
                
    
    
                // Set the dependency resolver to be Autofac.
                var container = builder.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            }
