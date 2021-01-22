    private T GetValue<T>(string[] keys)
    {
    	return GetValue<T>(keys, default(T));
    }
    
    private T GetValue<T>(string[] keys, T vDefault)
    {
    	T x = vDefault;
    	
    	string v = null;
    
    	for (int i = 0; i < keys.Length && String.IsNullOrEmpty(v); i++)
    	{
    		v = this.source[keys[i]];
    	}
    
    	if (!String.IsNullOrEmpty(v))
    	{
    		try
    		{
    			x = (typeof(T).IsSubclassOf(typeof(Enum))) ? (T)Enum.Parse(typeof(T), v) : (T)Convert.ChangeType(v, typeof(T));
    		}
    		catch(Exception e)
    		{
    			//do whatever you want here
    		}
    	}
    
    	return x;
    }
