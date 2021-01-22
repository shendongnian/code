        public class MvcApplication : System.Web.HttpApplication
        {
            
            private static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));
    
            void Application_Error(Object sender, EventArgs e)
            {
                Exception ex = Server.GetLastError().GetBaseException();
    
                log.Error("App_Error", ex);
            }
            
    
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                
                routes.MapRoute(
                    "Default",
                    "{controller}/{action}/{id}",
                    new { controller = "Home", action = "Index", id = "" }
                );
    
            }
    
            protected void Application_Start()
            {
                RegisterRoutes(RouteTable.Routes);
                log4net.Config.XmlConfigurator.Configure();
                  
            }
    
        }
