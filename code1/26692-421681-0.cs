    private readonly object _mapLock = new object();
    public void Method()
    {
        lock (_mapLock)
        {
            if (collection.Contains(item))
                collection.Get(item);
        }
    }
