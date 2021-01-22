    public object this[string indexer]
    {
        get
        {
            return CollectionOfStuff.FirstOrDefault(s => s.Name == indexer);
        }
    }
