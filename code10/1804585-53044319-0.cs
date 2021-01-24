    var list = query
        .Select(x => new EntityTypeName
        { 
            ..., 
            IsFirst = false, 
            IsLast = false
        }).ToList();
    
    if(list.Count > 0)
        list[0].IsFirst = true;
    if(list.Count > 1)
        list[list.Count-1].IsLast = true;
