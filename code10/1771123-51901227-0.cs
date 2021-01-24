    public PagedCollectionResult<T> Adapt<S, T>(PagedCollectionResultDTO<S> source)
    {
        if (source == null)
        {
            return null;
        }
        var target = new PagedCollectionResult<T>();
        
        // Get the type of S at runtime
        Type[] types = { typeof(S) };
        // Find the Adapt method on the TypeAdapter class that accepts an object of type S
        var adaptMethod = typeof(TypeAdapter).GetMethod("Adapt", types);
        foreach (var item in source.Data)
        {
            // for each item call the adapt method previously resolved and pass the item as parameter
            var parameters = new object[] { item };
            target.Data.Add((T)adaptMethod.Invoke(this, parameters));
        }
        target.Page = source.Page;
        target.PageSize = source.PageSize;
        target.Total = source.Total;
        return target;
    }
