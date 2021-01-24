    public static class Extensions
    {
    	public static ExpandoObject CreateObject(this IEnumerable<KeyValuePair<string,object>> source)
    	{
    	    dynamic returnValue = new ExpandoObject();
    	    var dict = returnValue as IDictionary<string, object>;
    	    foreach (var kvp in source)
    	    {
    	        dict.Add(kvp.Key, kvp.Value);
    	    }
    	    return returnValue;
    	}
    }
