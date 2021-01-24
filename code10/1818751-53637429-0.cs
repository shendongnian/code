    var results = new List<Item>();
    if(System.Web.HttpContext.Current.User.IsInRole("App_Inventory_LOC1_Access")) 
    {
        results.AddRange(items.Where(s => s.Facility == "LOC1"));
    }
    if(System.Web.HttpContext.Current.User.IsInRole("App_Inventory_LOC2_Access")) 
    {
        results.AddRange(items.Where(s => s.Facility == "LOC2"));
    }
    if(System.Web.HttpContext.Current.User.IsInRole("App_Inventory_LOC3_Access")) 
    {
        results.AddRange(items.Where(s => s.Facility == "LOC3"));
    }
