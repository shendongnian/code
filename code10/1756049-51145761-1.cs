    public async Task<TEntity> GetById(int id)
    {
        //Since TEntity is an IEntity, it is guaranteed to have an id property
        return await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
    }
