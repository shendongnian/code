    public static void TestMethod<T>(T parameter)
    {
    	if (parameter is ICollection && parameter.GetType().IsGenericType)
    	{
    
    		var temp = parameter as ICollection;
    		Console.WriteLine(temp.Count);
    	}
    	else
    	{
    		var temp = parameter as Cat;
    		Console.WriteLine(temp.Id);
    	}
    }
