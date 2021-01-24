    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
        DbContext db;
        public Repository(DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }
        public TEntity GetById(TKey id)
        {
            return db.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }
    }
