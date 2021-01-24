    public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
    
    
            //AutofacConfig.RegisterIoc();
            HttpConfiguration config = new HttpConfiguration();
    
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(x => x.FullName.Contains("API")).ToArray();
            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces()
                .InstancePerRequest();
    
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    
            ConfigureOAuth(app); //This must come first before we load the WebApiConfig below.
    
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
    
        }
