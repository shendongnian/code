    abstract class IncludeDefinition<TEntity>
    {
        public abstract IQueryable<TEntity> Include(IQueryable<TEntity> entities);
    }
    class IncludeDefinition<TEntity, TProperty> : IncludeDefinition<TEntity>
    {
        public IncludeDefinition(Expression<Func<TEntity, TProperty>> includeEx)
        {
            _includeEx = includeEx;
        }
        private readonly Expression<Func<TEntity, TProperty>> _includeEx;
        public override IQueryable<TEntity> Include(IQueryable<TEntity> entities)
        {
            return entities.Include(_includeEx);
        }
    }
