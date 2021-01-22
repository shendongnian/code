    MyObject A = GetA(); 
    MyObject B = GetB(); 
     
    List<MyObject> allObjects = 
      GetObjects(A) 
      .Concat(GetObjects(B)) 
      .GroupBy(x => x.Id) //rule out duplicates 
      .Select(g => g.First()) 
      .ToList(); 
     
    ILookup<string, string> lookupByParentId = allObjects 
      .Where(x => x.Parent != null) 
      .ToLookup(x => x.Parent.Id, x => x.Id); 
     
    Dictionary<string, CombinedObject> allCombinedObjects = allObjects 
      .Select(x => new CombinedObject() 
      { 
        Id = x.Id, 
        Children = null;
      }) 
      .ToDictionary(x => x.Id); 
    
    foreach(CombinedObject co in allCombinedObjects.Values)
    {
      co.Children = lookupByParentId[co.Id]
        .Select(childId => allCombinedObjects[childId])
        .ToList();
    }
    
    
    HashSet<string> rootNodeKeys = new HashSet(allObjects 
      .Where(x => x.Parent == null) 
      .Select(x => x.Id) 
      ); 
     
    List<CombinedObject> rootNodes = allCombinedObjects.Values
      .Where(x => rootNodeKeys.Contains(x.Id)) 
      .ToList(); 
