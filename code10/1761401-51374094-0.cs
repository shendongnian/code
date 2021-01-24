    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.Add("ProductDetails", new SeoFriendlyRoute("drink/{id}",
                new RouteValueDictionary(new { controller = "Drink", action = "Index" }),
                new MvcRouteHandler()));
        }
    }
