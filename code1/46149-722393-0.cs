    var dict1 = list1.ToDictionary(l1 => l1.Name);
    var dict2 = list2.ToDictionary(l2 => l2.Name);
        //get the full list of names.
    var names = dict1.Keys.Union(dict2.Keys).ToList();
        //produce results
    var result = names
    .Select( name =>
    {
      Person p1 = dict1.ContainsKey(name) ? dict1[name] : null;
      Person p2 = dict2.ContainsKey(name) ? dict2[name] : null;
          //left only
      if (p2 == null)
      {
        p1.Change = 0;
        return p1;
      }
          //right only
      if (p1 == null)
      {
        p2.Change = 0;
        return p2;
      }
          //both
      p2.Change = p2.Value - p1.Value;
      return p2;
    }).ToList();
