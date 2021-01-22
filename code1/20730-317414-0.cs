    // Suppose we could do this...
    public List<IDisposable> GetDisposables()
    {
        return new List<MemoryStream>();
    }
    // Then we could do this
    List<IDisposable> disposables = GetDisposables();
    disposables.Add(new Form());
