    public class FilterEntity<TEntity> where TEntity: class
    {
        YourDbContext _dbContext = new YourDbContext();
        public async Task<List<TEntity>> GetFilteredEntityList(string name, string lastName)
        {
            DbSet<TEntity> dbSet = _dbContext.Set<TEntity>();
            IQueryable<TEntity> entityListQueryable = dbSet;
            if (!string.IsNullOrEmpty(name))
            {
                entityListQueryable = entityListQueryable.Where("Name == @0", name);
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                entityListQueryable = entityListQueryable.Where("LastName == @0", lastName);
            }
            return await entityListQueryable.ToListAsync();
        }
    }
