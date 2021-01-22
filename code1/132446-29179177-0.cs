    public T Reload<T>(T entity) where T : class, IEntityId
    {
        ((IObjectContextAdapter)_dbContext).ObjectContext.Detach(entity);
        return _dbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
    }
