     public class MvcApplication : System.Web.HttpApplication
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                //routes.MapRoute(
                //    "Default",                                              // Route name
                //    "{controller}/{action}/{id}",                           // URL with parameters
                //    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                //);
                
                routes.MapRoute(
                        "FooBar",
                        "{siteLanguage}/bar/{fizz1}/{fizz2}/{fizz3}/{fizz4}",
                        new { controller = "Foo", action = "Bar", fizz3 = "", fizz4 = "" }
                );
    
            }
    
            protected void Application_Start()
            {
                RegisterRoutes(RouteTable.Routes);
            }
        }
