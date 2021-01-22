    public static IEnumerable<T> Subtract<T>(IEnumerable<T> source, IEnumerable<T> other)
    {
    	return Intersect(source, other, EqualityComparer<T>.Default);
    }
    
    public static IEnumerable<T> Subtract<T>(IEnumerable<T> source, IEnumerable<T> other, IEqualityComparer<T> comp)
    {
    	Dictionary<T, object> dict = new Dictionary<T, object>(comp);
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
