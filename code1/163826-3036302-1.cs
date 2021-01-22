    // put one into a dict for faster access
    var dict2 = list2.ToDictionaty(x => x.Name, x);
    
    // merge the lists using ??
    var merged = list1.Select(x => 
        new Project()
        {
          Name = x.Name,
          Type = x.Type ?? dict2[x.Name].Type,
          Priority = x.Priority ?? dict2[x.Name].Priority 
        });
