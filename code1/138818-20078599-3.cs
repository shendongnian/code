    public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                 ...
                 routes.MapRoute(
                 "MyRoute",
                 "{controller}/{action}/{idOne}/{idTwo}",
                 new
                 {
                     controller = "Employee", // 
                     action = "Show",
                     idOne = UrlParameter.Optional,
                     idTwo= UrlParameter.Optional
                 }, new { idOne = @"\d{1,5}" });
    
            }
        }
