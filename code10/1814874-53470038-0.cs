    public class Repository<TDbContext> where TDbContext : DbContext
    {
        private TDbContext _context { get; }
        public Repository(TDbContext context)
        {
           _context = context;
        }
        
        public TEntity Create<TEntity>(TEntity entity) where TEntity : class
        {
            if(entity != null)
            {
                var dataSet = _context.Set<TEntity>();
                if(entity is IEnumerable)
                {
                    dataSet.AddRange(entity);
                }
                else
                {
                    dataSet.Add(entity);
                }
                _context.SaveChanges();
            }
            return entity;
        }
    }
