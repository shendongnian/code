    public static class AutoMapperExtensions
    {
    	public static T Map<T>(this IMappingEngine engine, params object[] sources) where T : class
    	{
    		if (sources == null || sources.Length == 0)
    			return default(T);
    
    		var destinationType = typeof (T);
    		var result = engine.Map(sources[0], sources[0].GetType(), destinationType) as T;
    		for (int i = 1; i < sources.Length; i++)
    		{
    			engine.Map(sources[i], result, sources[i].GetType(), destinationType);
    		}
    
    		return result;
    	}
    }
