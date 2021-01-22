    MyObject A = GetA();
    MyObject B = GetB();
    
    List<MyObject> allObjects =
      GetObjects(A)
      .Concat(GetObjects(B))
      .GroupBy(x => x.Id) //rule out duplicates
      .Select(g => g.First())
      .ToList();
    
    ILookup<string, MyObject> lookupByParentId = allObjects
      .Where(x => x.Parent != null)
      .ToLookup(x => x.Parent.Id);
    
    HashSet<string> rootNodeKeys = new HashSet(allObjects
      .Where(x => x.Parent == null)
      .Select(x => x.Id)
      );
    
    List<CombinedObject> allCombinedObjects = allObjects
      .Select(x => new CombinedObject()
      {
        Id = x.Id,
        Children = lookupByParentId[x.Id].ToList()    
      })
      .ToList();
    
    List<CombinedObject> rootNodes = allCombinedObjects
      .Where(x => rootNodeKeys.Contains(x.Id))
      .ToList();
