    public interface IQueryRepository<TEntity>
         where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        IQueryRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> referenceExpression);
    }
    public interface IGenericRepository<TEntity> : IQueryRepository<TEntity>
         where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params IncludeDefinition<TEntity>[] include);
        // other methods like GetByID, Add, Update...
    }
