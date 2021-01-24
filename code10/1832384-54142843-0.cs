    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection Routes)
        {
            Routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            Routes.MapMvcAttributeRoutes();
            Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                namespaces: new string[] { "YourControllerNamespace.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );           
        }
    }
