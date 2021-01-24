    public class Repository<TEntity> where TEntity : class
    {
        private DbContext db;
        private DbSet<TEntity> dbSet;
        public Repository(DbContext ctx)
        {
            db = ctx;
            dbSet = db.Set<TEntity>();
        }
        internal IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
        ... // Other CRUD operations
    }
