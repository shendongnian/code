    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Build up routing table based from the database.  
            //This will stop us from having to create shedloads of these statements each time a new language, controller or action is added
            using (GeneralEntities db = new GeneralEntities())
            {
                List<RoutingTranslation> rt = db.RoutingTranslations.ToList();
                foreach (var r in rt)
                {
                    routes.MapRoute(
                        name: r.LanguageCode + r.ControllerDisplayName + r.ActionDisplayName,
                        url: r.LanguageCode + "/" + r.ControllerDisplayName + "/" + r.ActionDisplayName + "/{id}",
                        defaults: new { culture = r.LanguageCode, controller = r.ControllerName, action = r.ActionName, id = UrlParameter.Optional },
                        constraints: new { culture = r.LanguageCode }
                    );
                }                
            }
            //Global catchall
            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new {culture = CultureHelper.GetDefaultCulture(), controller = "Default", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
