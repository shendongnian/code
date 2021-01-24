    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        //add this part
        filters.Add(new ThrottleAttribute());
    }
