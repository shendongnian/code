    public T Get<T>(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) where T : class, IEntity
    {
        var result = this.Set<T>().AsQueryable();
        if (include != null)
            result = include(result);
        return result.FirstOrDefault(x => x.Id == id);
    }
