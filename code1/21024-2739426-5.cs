    public static void Main()
    {
    	List<int> foo = new List<int>(new int[]{ 1, 2, 3});
    	List<int> bar = foo.ConvertAll(new Converter<int, int>(delegate(int x){ return x * 2; }));	// list comprehension
    
    	foreach (int x in bar)
    	{
    		Console.WriteLine(x);  // should print 2 4 6
    	}
    }
