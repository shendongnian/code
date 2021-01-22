    private ICollection<T> items;
    
    public T[] Items
    {
        get { return new List<T>(items).ToArray(); }
    }
