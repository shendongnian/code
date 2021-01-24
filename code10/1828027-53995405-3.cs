    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Default MVC stuff
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // create container builder to register dependencies in
            var services = new ServiceCollection();
            // register controller in the controller
            services.AddScoped<HomeController>();
            // Build the container while ensuring scopes are validated
            ServiceProvider container = services.BuildServiceProvider(true);
            
            // Replace default controller factory
            ControllerBuilder.Current.SetControllerFactory(
                new MsDiControllerFactory(container)); 
        }
    }
