    if (stringName.In("foo", "bar", "baz"))
    {
    
    }
    // in an extension method class
    public static bool In<T>(this T value, params T[] values)
    {
    	return values.Contains(value);
    }
