    public static IEnumerable<T> Intersect(IEnumerable<T> source, IEnumerable<T> other)
    {
    	Dictionary<T, object> dict = new Dictionary<T, object>();
    	foreach(T item in source)
    	{
    		dict[item] = null;
    	}
    	
    	foreach(T item in other)
    	{
    		dict.Remove(item);
    	}
    	
    	return dict.Keys;
    }
