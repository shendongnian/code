    public class MvcApplication : System.Web.HttpApplication
    {
    ...
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); 
        }
    ...
    }
