    public static class SafeBsonSerializerRegistry
    {
        private static ConcurrentDictionary<Type, IBsonSerializer> _cache = new ConcurrentDictionary<Type,IBsonSerializer>();
    	
    	public static IBsonSerializer<T> LookupSerializer<T>()
        {
             return (IBsonSerializer<T>)LookupSerializer(typeof(T));
        }
    	
    	public static IBsonSerializer LookupSerializer(Type type)
    	{
    		if (type == null)
    			throw new ArgumentNullException("type");
    		
    		var typeInfo = type.GetTypeInfo();
    		if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
    		{
    			var message = string.Format("Generic type {0} has unassigned type parameters.", BsonUtils.GetFriendlyTypeName(type));
    			throw new ArgumentException(message, "type");
    		}
    		
    		IBsonSerializer serializer;
    		
    		if(_cache.TryGetValue(type, out serializer))
    			return serializer;
    		return null; //Note, this is where the BsonSerializerRegistry would GetOrAdd().
    	}
    	
    	
    	
    	public static void RegisterSerializer<T>(IBsonSerializer<T> serializer)
    	{
    		RegisterSerializer(typeof(T), serializer);
    	}
    	
    	public static void RegisterSerializer(Type type, IBsonSerializer serializer)
    	{
    		if (type == null)
    			throw new ArgumentNullException("type");
    		if (serializer == null)
    			throw new ArgumentNullException("serializer");
    		
    		var typeInfo = type.GetTypeInfo();
    		if (typeof(BsonValue).GetTypeInfo().IsAssignableFrom(type))
    		{
    			var message = string.Format("A serializer cannot be registered for type {0} because it is a subclass of BsonValue.", BsonUtils.GetFriendlyTypeName(type));
    			throw new BsonSerializationException(message);
    		}
    		
    		if (typeInfo.IsGenericType && typeInfo.ContainsGenericParameters)
    		{
    			var message = string.Format("Generic type {0} has unassigned type parameters.", BsonUtils.GetFriendlyTypeName(type));
    			throw new ArgumentException(message, "type");
    		}
    		
    		if (!_cache.TryAdd(type, serializer))
    		{
    			var message = string.Format("There is already a serializer registered for type {0}.", BsonUtils.GetFriendlyTypeName(type));
    			throw new BsonSerializationException(message);
    		}
    		
    		//call to the actual BsonSerializer
    		BsonSerializer.RegisterSerializer(type, serializer);
    	}
    
    }
