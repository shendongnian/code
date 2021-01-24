    public IQueryable<T> GetQuery()
    {
        var queryHandlerList = new List<QueryHandler<T>>()
        {
            new IntQuery<T>(//Properties),
            new DateTimeQuery<T>(//Properties),
            new StringQuery<T>(//Properties),
            new BoolQuery<T>(//Properties),
            new GuidQuery<T>(//Properties),
            new EnumQuery<T>(//Properties)
        };
    }
    return query = queryHandlerList.FirstOrDefault(h => GetType<T>(h, property.PropertyType)).Handle();
    private bool GetType<T>(QueryHandler<T> handler, Type type) where T: class
    {
        if (handler.Types.FirstOrDefault(t => t == type) == type || handler.Types.FirstOrDefault(t => t == type.BaseType) == type.BaseType) return true;
        return false;
    }
