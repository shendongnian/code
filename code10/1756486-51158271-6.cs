    public interface IOMSService<TEntity>
    {
        IEnumerable<TModel> Get<TModel>(
            Expression<Func<TEntity, bool>> predicate, 
            params Expression<Func<TEntity, object>>[] includes) 
    }
