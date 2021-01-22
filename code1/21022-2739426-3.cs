    public static void Main()
    {
    	int[] foo = new int[]{ 1, 2, 3};	
    	int[] bar = Array.ConvertAll(foo, new Converter<int, int>(delegate(int x){ return x * 2; }));	// list comprehension
    
    	foreach (int x in bar)
    	{
    		Console.WriteLine(x);  // should print 2 4 6
    	}
    }
