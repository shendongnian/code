    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> dbSet;
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return Get(filter, orderBy, new IncludeDefinition<TEntity>[0]);
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params IncludeDefinition<TEntity>[] includes)
        {
            IQueryable<TEntity> query = dbSet;
            foreach (var item in includes)
            {
                query = item.Include(query);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IQueryRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> referenceExpression)
        {
            return new GenericQueryRepositoryHelper<TEntity>(this, new IncludeDefinition<TEntity, TProperty>(referenceExpression));
        }
        // other methods like GetByID, Add, Update...
    }
