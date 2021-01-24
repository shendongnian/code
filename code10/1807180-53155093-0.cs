    public interface IDataSet<T> : IQueryable<T>
    	where T : class, new()
    {
    	T AddOrUpdate(T entity);
    	void Remove(T entity);
        void Commit();
    }
    
    public class EntityFrameworkDataSet<T> : IDataSet<T>
    	where T : class, new()
    {
    	private readonly IDbSet<T> _underlyingSet;
    
    	public EntityFrameworkDataSet(DbContext ctx)
    	{
    		_underlyingSet = ctx.Set<T>();
    	}
    	
    	//Implement IDataSet<T> 
    	//Implement IQueryable<T> redirecting to IDbSet<T>
    }
