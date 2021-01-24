    public interface IId
    {
        pubic long Id {get;set;}        
    }
    
    ...
    
    class Customer : IId { pubic long ID{get;set;} ...}
    class Employee : IId { pubic long ID{get;set;} ...}
    
    public async Task<TEntity> GetById<TEntity>(int id) where TEntity : IId
    {
        return await _dbContext.Set<TEntity>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
    }
   
