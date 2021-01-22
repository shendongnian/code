    public IEnumerable<SomeType> FindResults(IQueryable<SomeType> collection) {
        foreach (var c in collection)
        {
            if (doComplicatedQuery(c)) {
                yield return c;
            }
        }
    }
    // elsewhere
    foreach (var goodItem in FindResults(GetCollection())) {
       // do stuff.
    }
