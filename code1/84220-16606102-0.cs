    protected void Application_Start()
    {
        // your code here and then
        RegisterGlobalFilters(GlobalFilters.Filters);
    }    
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new MyActionFilterAttribute());
    }
