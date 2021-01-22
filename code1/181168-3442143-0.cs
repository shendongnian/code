    var map = allElements.ToDictionary(x => x.Id);    
    if (!someElements.All(id => map.ContainsKey(id))
    {
        // Return early
    }
    var list = someElements.Select(x => map[x])
                           .ToList();
