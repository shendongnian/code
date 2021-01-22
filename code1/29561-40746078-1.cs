        public class FilterConfig
        {
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                // Add custom attribute here
                filters.Add(new CultureAttribute());
            }
        }    
