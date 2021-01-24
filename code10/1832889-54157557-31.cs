    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetEntities(Expression<Func<TEntity, bool>> condition = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        
        Task<bool> IsEntityExists(Expression<Func<TEntity, bool>> filter = null);
        void InsertEntity(TEntity entity);
        void InsertEntities(List<TEntity> entities);
        void UpdateEntity(TEntity entity, params string[] excludeProperties);
        void DeleteEntity(TEntity entity);
        void DeleteEntities(List<TEntity> entities);
        Task<bool> IsTableEmptyAsync();
    }
