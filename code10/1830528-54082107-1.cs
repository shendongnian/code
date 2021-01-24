    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly ServiceAppContext context;
        private DbSet<TEntity> dbSet;
        public DbRepository(ServiceAppContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }
        public Task AddAsync(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }
        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }
        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }
        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
        public bool Contains(TEntity entity)
        {
            return this.dbSet.Contains(entity);
        }
    }
