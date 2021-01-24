    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.DependencyResolution;
    using System.Data.SQLite.EF6;
    using System.Data.SQLite;
    
    class SQLiteProviderInvariantName : IProviderInvariantName
    {
    	public static readonly SQLiteProviderInvariantName Instance = new SQLiteProviderInvariantName();
    	private SQLiteProviderInvariantName() { }
    	public const string ProviderName = "System.Data.SQLite.EF6";
    	public string Name { get { return ProviderName; } }
    }
    
    class SQLiteDbDependencyResolver : IDbDependencyResolver
    {
    	public object GetService(Type type, object key)
    	{
    		if (type == typeof(IProviderInvariantName))
    		{
    			if (key is SQLiteProviderFactory || key is SQLiteFactory)
    				return SQLiteProviderInvariantName.Instance;
    		}
    		return null;
    	}
    
    	public IEnumerable<object> GetServices(Type type, object key)
    	{
    		var service = GetService(type, key);
    		if (service != null) yield return service;
    	}
    }
