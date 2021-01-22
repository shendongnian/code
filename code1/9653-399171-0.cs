    public void Add(TKey key, TValue value)
    {
        lock (this.syncRoot)
        {
            this.innerDictionary.Add(key, value);
        }
    }
    public bool ContainsKey(TKey key)
    {
        lock (this.syncRoot)
        {
            return this.innerDictionary.ContainsKey(key);
        }
    }
