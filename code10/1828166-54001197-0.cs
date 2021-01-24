    static void IterateEnum<T>(T enumSource)
    {
    	foreach(var item in Enum.GetValues(typeof(T)))
    	{
    		Console.WriteLine(item);
    	}
    }
