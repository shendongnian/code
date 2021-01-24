    public class MvcApplication : System.Web.HttpApplication
    {
        // this class is doing all staff with reflection to create controller class
        private readonly InterfaceReader _reader = new InterfaceReader();
    
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
    
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
    
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Services.Replace(typeof(IHttpControllerActivator), new MyServiceActivator(_reader, config));
        }
    }
