    public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                // Here I have created a custom "Default" route that will route users to the "YourAction" method within the "FooController" controller.
                    routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "FooController", action = "Index", id = UrlParameter.Optional }
                );
            }
