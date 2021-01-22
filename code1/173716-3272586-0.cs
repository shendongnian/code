    IEnumerable<Item> GetAllDependencies(Item i)
    {
        IEnumerable<Item> a = new Item[] { i };
        IEnumerable<Item> b = i.Dependencies
                               .SelectMany(d => GetAllDependencies(d))
                               .Distinct();
        return a.Concat(b);
    }
