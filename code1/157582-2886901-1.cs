    protected void Dispose()
    {
        is_disposing = true;
        foreach(T item in this)
        {
            item.Dispose();
        }
    }
