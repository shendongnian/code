        protected void Application_Start()
        {
            //...
            RegisterGlobalFilters(GlobalFilters.Filters);
            //...
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new FilterAllActions());
        }
