    public interface IId
    {
        public long Id {get;set;}        
    }
    
    // ...
    
    class Customer : IId { public long ID{get;set;} ...}
    class Employee : IId { public long ID{get;set;} ...}
    
    public async Task<TEntity> GetById<TEntity>(int id) where TEntity : IId
    {
        return await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
    }
   
