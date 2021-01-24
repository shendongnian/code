    class CustomModelCacheKeyFactory : IModelCacheKeyFactory
    {
    	public object Create(DbContext context) => new CustomModelCacheKey(context);
    }
    
    class CustomModelCacheKey
    {
    	(Type ContextType, string CustomTableName) key;
    	public CustomModelCacheKey(DbContext context)
    	{
    		key.ContextType = context.GetType();
    		key.CustomTableName = (context as CustomDbContext)?.CustomTableName;
    	}
    	public override int GetHashCode() => key.GetHashCode();
    	public override bool Equals(object obj) => obj is CustomModelCacheKey other && key.Equals(other.key);
    }
