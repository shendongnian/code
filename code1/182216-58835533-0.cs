    public EntityNotFoundException GetEntityNotFoundException(Type entityType, object id)
    {
        return new EntityNotFoundException($"The object '{entityType.Name}' with given id '{id}' not found.");
    }
    public TEntity GetEntity<TEntity>(string id)
    {
        var entity = session.Get<TEntity>(id);
        if (entity == null)
            throw GetEntityNotFoundException(typeof(TEntity), id);
        return entity;
    }
