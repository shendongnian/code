    public static class Helper
    {
    	
    	public static object GetQueryable(string type) {
    		var method = typeof(Helper).GetMethod(nameof(CreateList));
    		return method.MakeGenericMethod(Type.GetType(type)).Invoke(null, new object[0]);
    	}
    
    	public static IQueryable<T> CreateList<T>()
    	{
    		return new List<T>().AsQueryable();
    	}
    }
