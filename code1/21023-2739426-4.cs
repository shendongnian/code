    public static void Main()
    {
    	var foo = new List<int>{ 1, 2, 3};
    	var bar = foo.ConvertAll(x => x * 2);    // list comprehension
    
    	foreach (var x in bar)
    	{
    		Console.WriteLine(x);  // should print 2 4 6
    	}
    }
