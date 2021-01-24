    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GaragemDoPneuDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(GaragemDoPneuDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetEntities(Expression<Func<TEntity, bool>> condition = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (condition != null)
            {
                query = query.Where(condition);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query;
        }
        public async Task<bool> IsEntityExists(Expression<Func<TEntity, bool>> condition)
        {
            bool status = false;
            if (condition != null)
            {
                status = await _dbSet.AnyAsync(condition);
            }
            return status;
        }
        public  void InsertEntity(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public void InsertEntities(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public void UpdateEntity(TEntity entity, params string[] excludeProperties)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            foreach (string property in excludeProperties)
            {
                _dbContext.Entry(entity).Property(property).IsModified = false;
            }
        }
        public void DeleteEntity(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteEntities(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public async Task<bool> IsTableEmptyAsync()
        {
            bool hasAny = await _dbSet.AnyAsync();
            return !hasAny;
        }
    }
