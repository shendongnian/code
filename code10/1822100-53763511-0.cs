    for (var i = 0;i <= 3; i++)
    {
        var typeIdOfObjectType = 
                        db? // If db is null, then typeIdOfObjectType will be null
                          .Objects? // The same if .Objects is null
                          .Where(x => x.ObjectsName == ObjectTypeName)
                          .Select(x => x.ObjectTgId)
                          .First();
        if(typeIdOfObjectType == null)
        {
            continue; // Jump to the next iteration
        }
        // (Anything below here will be skipped for any iteration
        // where typeIdOfObjectType was null) 
    }
