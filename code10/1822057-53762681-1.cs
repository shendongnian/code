    public IEnumerable<string> Flattener(object o)
    {
    	if (o is IEnumerable<string> strings)
    	{
    		return strings;
    	}
    	if (o is string s)
    	{
    	   return new[]{s};
    	}
    	return new[]{"?"};
    }
