    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Context for the database
        /// </summary>
        protected readonly DataBaseContext DbContext;
        protected readonly DbSet<T> DbSet;
        // ...
        public async Task<(T, int)> AddAsync(T entity, bool autoSaveChangesAsync = false)
        {
            Requires.ArgumentNotNullAndNotDefault(entity);
            GetDbContext().Set<T>().Add(entity);
            return (entity, await saveChangesAsync(autoSaveChangesAsync));
        }
        public async Task<(IEnumerable<T>, int)> AddAsync(IEnumerable<T> entities, bool autoSaveChangesAsync = false)
        {
            Requires.ArgumentNotNullAndNotDefault(entities);
            var addedEntities = new List<T>();
            foreach (var entity in entities)
                addedEntities.Add((await AddAsync(entity, false)).Item1);
            return (addedEntities, await saveChangesAsync(autoSaveChangesAsync));
        }
        public Task<T> GetByIdAsync(Guid id)
        {
            Requires.ArgumentNotNullAndNotDefault(id);
            return DbSet.FindAsync(id);
        }
        // ...
        public async Task<(T, int)> UpdateAsync(T entity, int key, bool autoSaveChangesAsync = false)
        {
            if (entity == null)
                return (null, 0);
            T existingEntity = await DbContext.Set<T>().FindAsync(key);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                return (existingEntity, await saveChangesAsync(autoSaveChangesAsync));
            }
            return (existingEntity, 0); // Because 0 entity have been written into the database
        }
        // ...
        private async Task<int> saveChangesAsync(bool autoSaveChangesAsync)
        {
            if (autoSaveChangesAsync)
                return await SaveChangesAsync();
            else
                return 0; // Because 0 entity have been written into the database
        }
        public Task<int> SaveChangesAsync() => GetDbContext().SaveChangesAsync();
    }
