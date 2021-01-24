    var facilities = new List<string>();
    if(System.Web.HttpContext.Current.User.IsInRole("App_Inventory_LOC1_Access")) 
    {
        facilities.Add("LOC1");
    }
    // same for other facilities
    // ...
    items = items.Where(s => facilities.Contains(s.Facility));
