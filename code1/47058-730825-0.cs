    public IEnumerable<T> GetItems<T>()
    {
        Type myType = typeof(T);
        IDictionary<int, object> dictionary;
        if (!m_pool.TryGetValue(myType, out dictionary))
        {
            return new T[0];
        }
        return dictionary.Values.Cast<T>();
    }
