    protected void Application_Start()
    {
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        GlobalFilters.Filters.Add(new AntiForgeryExceptionAttribute());
    }
