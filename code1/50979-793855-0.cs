    public static T To<T>(this IConvertible obj) 
    {
    	Type t = typeof(T);
    	if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
    		t = t.GetGenericArguments()[0];
    
    	return (T)Convert.ChangeType(obj, t); 
    }
