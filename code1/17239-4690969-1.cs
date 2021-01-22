    public static string ToString<T>(this IEnumerable<T> self, string format)
    {
    	return self.ToString(i => String.Format(format, i));
    }
    
    public static string ToString<T>(this IEnumerable<T> self, Func<T, object> function)
    {
    	var result = new StringBuilder();
    
    	foreach (var item in self) result.Append(function(item));
    
    	return result.ToString();
    }
    public static string Join<T>(this IEnumerable<T> self, string separator)
    {
    	var result = new StringBuilder();
    
    	foreach (var item in self)
    	{
    		if (result.Length > 0) result.Append(separator);
    
    		result.Append(item);
    	}
    
    	return result.ToString();
    }
