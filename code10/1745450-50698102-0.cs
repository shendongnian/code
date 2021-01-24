    var list = new List<FlatItem>();
    var result = new List<NavigationItem>();
    // just a helper to remember ids
    var dict = new Dictionary<int, NavigationItem>();
    foreach (var item in list)
    {
       var nav = new NavigationItem()
                      {
                         ID = item.ID,
                         ParentID = item.ParentID,
                         Title = item.Title,
                         Children = new List<NavigationItem>()                                   
                      };
    
       if (!dict.ContainsKey(nav.ParentID))
          result.Add(nav);       
       else
          dict[nav.ParentID].Children.Add(nav);
       dict.Add(item.ID, nav);
    }
