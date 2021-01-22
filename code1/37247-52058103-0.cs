    
    public void Main()
    {
    	List<int> a = GetData<int>();
    	List<string> b = GetData<string>();
    }
    
    public List<T> GetData<T>()
    {
    	var type = typeof(T);
    	if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
    	{
    		type = type.GenericTypeArguments[0];
    	}
    
    	if (type == typeof(int))
    	{
    		var a = new List<int> { 1, 2, 3 };
    		return a.Select(v => v != null ? (T)Convert.ChangeType(v, type) : default(T)).ToList();
    	}
    	else if (type == typeof(string))
    	{
    		var b = new List<string> { "a", "b", "c" };
    		return b.Select(v => v != null ? (T)Convert.ChangeType(v, type) : default(T)).ToList();
    	}
    }
