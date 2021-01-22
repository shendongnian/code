    public void MyMethod(HashSet<SomeType> set)
    {
        // remove null item in case it's there
        set.Remove(null);
        
        foreach (var item in set)
        {
            // safe to assume item is not null
            item.DoSomething();
        }
    }
