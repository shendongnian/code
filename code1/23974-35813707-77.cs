    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("nl-NL"), 0);
        }
    }
