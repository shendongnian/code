    public bool TryGetValue(key thekey, out SomeRef result)
    {
        lock(myLock) { return this.dict.TryGetValue(thekey, out result); }
    }
    public void Add(key thekey, SomeRef value)
    {
        lock(myLock) { this.dict.Add(thekey, value) }
    }
    // etc for each method you need to implement...
