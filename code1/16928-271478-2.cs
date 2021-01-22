    public static void Split<T>(this T[] array, 
        Func<T,bool> determinator, 
        IList<T> onTrue, 
        IList<T> onFalse)
    {
    	if (onTrue == null)
    		onTrue = new List<T>();
    	else
    		onTrue.Clear();
    
    	if (onFalse == null)
    		onFalse = new List<T>();
    	else
    		onFalse.Clear();
    
    	if (determinator == null)
    		return;
    
    	foreach (var item in array)
    	{
    		if (determinator(item))
    			onTrue.Add(item);
    		else
    			onFalse.Add(item);
    	}
    }
