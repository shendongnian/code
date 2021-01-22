    public IQueryable<T> FindAll()
    {
        return _ctx.GetTable<T>();
    }
    public void Add(T entity)
    {
        _ctx.GetTable<T>().InsertOnSubmit(entity);
    }
