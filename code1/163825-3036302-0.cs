    var dict2 = list2.ToDictionaty(x => x.Name, x);
    
    var merged = list1.Select(x => 
        new Project()
        {
          Name = x.Name,
          Type = x.Type ?? dict2[x.Name].Type,
          Priority = x.Priority ?? dict2[x.Name].Type
        });
