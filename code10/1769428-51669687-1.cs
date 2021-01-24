    public static void TestMethod<T>(T parameter)
    {
    	// Check if it is a ICollection of any object
    	if (parameter is ICollection && parameter.GetType().IsGenericType)
    	{
    		var itemCount = ((ICollection)parameter).Count;
    	}
    	else
    	{
    		// write your else logic
    	}
    }
