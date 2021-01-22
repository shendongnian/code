    public void SomeMethod<T>(string var1, IEnumerable<T> items, int count)
    {
        if (string.IsNullOrEmpty(var1))
            throw new ArgumentNullException("var1");
    
        if (items == null)
            throw new ArgumentNullException("items");
    
        if (count < 1)
            throw new ArgumentOutOfRangeException("count");
    
        ... etc ....
    }
