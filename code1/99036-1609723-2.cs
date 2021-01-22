    IEnumerable<string> results = Enumerable.Empty<string>();
    for(....)
    {
        IEnumerable<string> subset = GetSomeSubset(...);
        results = results.Union(subset);
    }
