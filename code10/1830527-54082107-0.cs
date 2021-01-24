    public interface IRepository<TEntity>
     where TEntity : class
    {
        IQueryable<TEntity> All();
        bool Contains(TEntity entity);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();
    }
