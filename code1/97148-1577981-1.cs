    public void DoSomething<T>(IEnumerable<T> list)
    {
        // Do Something
    }
    
    public void DoSomething<T>(T item)
    {
        DoSomething(new T[] { item });
    }
