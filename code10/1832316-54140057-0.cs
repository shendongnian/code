    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var seq = GetNumbers().Concat(Enumerable.Range(1, 1).SelectMany(_ => GetNumbers())).FirstOrDefault();
    		Console.WriteLine(seq);
    	}
    
    	static int[] GetNumbers()
    	{
    		Console.WriteLine("GetNumbers called");
    		return new[]{1, 2, 3};
    	}
    }
