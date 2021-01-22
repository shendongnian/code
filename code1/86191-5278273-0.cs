    public IQueryable<T> Queryable<T>()
    {
        IQueryable<T> queryable = SessionFactory.OpenSession().Queryable<T>();
        queryable = queryable.Cacheable<T>();
    
        return queryable;
    }
