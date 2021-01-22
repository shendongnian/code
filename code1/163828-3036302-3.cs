    // put one into a dict for faster access
    var dict2 = list2.ToDictionaty(x => x.Name, x);
    
    // merge the lists using ??
    var merged = list1.Select(x => 
    {
        var p2 = dict2[x.Name];
        return new Project()
        {
          Name = x.Name,
          Type = x.Type ?? p2.Type,
          Priority = x.Priority ?? p2.Priority 
        }
    });
