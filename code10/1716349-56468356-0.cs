    public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);    
    
                ConfigureIoC(app, config);
                Components.Config();
    
                Auth.ConfigureForApi(app);
    
                app.UseAutofacWebApi(config);
                app.UseCors(CorsOptions.AllowAll);
                app.UseWebApi(config);
                config.EnsureInitialized();
            }
    
            private void ConfigureIoC(IAppBuilder app, HttpConfiguration config)
            {
                IoC.RegisterModules(
                    builder =>
                    {
                        builder.Register<IAuthenticationManager>(c => c.Resolve<IOwinContext>().Authentication).InstancePerRequest();
                        builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();
                        builder.RegisterApiControllers(typeof(Startup).Assembly).PropertiesAutowired();
                    },
                    container =>
                    {
                        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                        app.UseAutofacMiddleware(container);
    
                    },
                    true
                    );
            }
    
        }
