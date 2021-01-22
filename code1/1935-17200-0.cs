    public delegate T SomeDelegate(K obj);
    public IEnumerable<T> DoActionOnList(IEnumerable<K> list, SomeDelegate action)
    {
        foreach (var i in list)
            yield return action(i);
    }
