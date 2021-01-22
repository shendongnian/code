    IEnumerable<string> results = null;
    for(....)
    {
        IEnumerable<string> subset = GetSomeSubset(...);
        if(results == null)
        {
            results = subset;
        }
        else
        {
            results = results.Union(subset);
        }
    }
