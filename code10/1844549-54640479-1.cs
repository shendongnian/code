    public interface IReadAccess<TEntity>  
    {  
        Task<IEnumerable<TEntity>> GetAll();   
        Task<IEnumerable<TEntity>> Find(FormattableString whereClause, object whereClauseObject);
    
    } 
