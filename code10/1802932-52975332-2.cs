    public class RouteConfig
    {
    	public static void RegisterRoutes(RouteCollection routes)
    	{
    		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
    		routes.MapRoute(
    			name: "FilesRoute",
    			url: "Home/{action}/{id}",
    			defaults: new { controller = "Home", id = UrlParameter.Optional }
    		);
    
    		routes.MapRoute(
    			name: "Files",
    			url: "api/Home/{action}/{id}",
    			defaults: new { controller = "Home", id = UrlParameter.Optional }
    		);
    
    
    		routes.MapRoute(
    			 name: "Default",
    			 url: "{controller}/{action}/{id}",
    			 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    		);
    
    	}
    }
