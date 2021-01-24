    public class DbQueryProxy<TResult> : IOrderedQueryable<TResult>, IListSource
    {
    	private readonly DbQuery<TResult> _DbQuery;
    
    	internal DbQueryProxy(DbQuery<TResult> entry)
    	{
    		_DbQuery = entry;
    	}
    
    	protected DbQueryProxy()
    	{
    	}
    
    	public static implicit operator DbQuery<TResult>(DbQueryProxy<TResult> entry) => entry._DbQuery;
    
    	public static implicit operator DbQueryProxy<TResult>(DbQuery<TResult> entry) => new DbQueryProxy<TResult>(entry);
    
    	#region Interfaces
    
    	Type IQueryable.ElementType => ((IQueryable)_DbQuery).ElementType;
    
    	Expression IQueryable.Expression => ((IQueryable)_DbQuery).Expression;
    
    	IQueryProvider IQueryable.Provider => ((IQueryable)_DbQuery).Provider;
    
    	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_DbQuery).GetEnumerator();
    
    	IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator() => ((IEnumerable<TResult>)_DbQuery).GetEnumerator();
    
    	bool IListSource.ContainsListCollection => ((IListSource)_DbQuery).ContainsListCollection;
    
    	IList IListSource.GetList() => ((IListSource)_DbQuery).GetList();
    
    	#endregion Interfaces
    
    	#region DbQuery<TResult>
    
    	public string Sql => _DbQuery.Sql;
    
    	public DbQueryProxy<TResult> AsNoTracking() => _DbQuery.AsNoTracking();
    
    	public override bool Equals(object obj) => _DbQuery.Equals(obj);
    
    	public override int GetHashCode() => _DbQuery.GetHashCode();
    
    	public DbQueryProxy<TResult> Include(string path) => _DbQuery.Include(path);
    
    	public override string ToString() => _DbQuery.ToString();
    
    	#endregion DbQuery<TResult>
    }
