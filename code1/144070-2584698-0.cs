    public static IEnumerable OfType(this IEnumerable source, Type t)
    {
    	foreach(object o in source)
    	{
    		if(t.IsAssignableFrom(o.GetType()))
    			yield return o;
    	}
    }
