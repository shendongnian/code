    public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                
                //**This is the "Default" route created by Visual Studio when you create an MVC project
                //routes.MapRoute(
                //    name: "Default",
                //    url: "{controller}/{action}/{id}",
                //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    
                //** Here I have created a custom "Default" route that will route users to the "YourAction" method within the "FooController" controller.
                    routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "FooController", action = "YourAction", id = UrlParameter.Optional }
                );
            }
