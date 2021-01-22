    public IQuerable<T> CreateLinqQuery()
    {
        var query = session.Linq<T>();
        query.QueryOptions.SetCachable(true);
        return query;
    }
