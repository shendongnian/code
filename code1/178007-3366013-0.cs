    private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _cache = new Dictionary<Type,Dictionary<string,PropertyInfo>>();
    public static T GetProperty<T>(object obj, string name)
    {
    	if (obj == null)
    	{
    		throw new ArgumentNullException("obj");
    	}
    	else if (name == null)
    	{
    		throw new ArgumentNullException("name");
    	}
    
    	lock (_cache)
    	{
    		var type = obj.GetType();
    		var props = default(Dictionary<string, PropertyInfo>);
    		if (!_cache.TryGetValue(type, out props))
    		{
    			props = new Dictionary<string, PropertyInfo>();
    			_cache.Add(type, props);
    		}
    		var prop = default(PropertyInfo);
    		if (!props.TryGetValue(name, out prop))
    		{
    			prop = type.GetProperty(name);
    			if (prop == null)
    			{
    				throw new MissingMemberException(name);
    			}
    			props.Add(name, prop);
    		}
    		return (T)prop.GetValue(obj, null);
    	}
    }
