    class TypeNameComparer : IComparer<object>
    {
    	public int Compare(object x, object y)
    	{
    		x.GetType().FullName.CompareTo(y.GetType().FullName);
    	}
    }
    private static void Main()
    {
    	object[] mixed = {42, "Hello, world!", System.Guid.NewGuid()};
    	BubbleSort(mixed, new TypeNameComparer());
    	
    	foreach (object obj in mixed)
    	{
    		System.Console.WriteLine(obj);
    	}
    }
