    public delegate bool Predicate<A>(A arg);
    ...
    public List<T> FindAll(Predicate<T> predicate)   
    {
        var result = new List<T>();
        foreach (T item in this)
            if (predicate(item))
                result.Add(item);
        return result;
    }
