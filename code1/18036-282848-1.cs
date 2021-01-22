    public void GetData<V>(ref Dictionary<int, V> dictionary)
    {
        dictionary = new Dictionary<int,V>(); // reassign reference.
    }
    public void GetData<V>(ref Dictionary<string, V> dictionary) { ... }
    public void GetData<V>(ref Dictionary<Guid, V> dictionary) { ... }
