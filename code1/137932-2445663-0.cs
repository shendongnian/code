    void Method<T>(IQueryable<T> query) where T : SomeType
    {
        foreach (T item in query)
        {
            int size = item.Size; // Size declared in SomeType
            // ...
        }
    }
