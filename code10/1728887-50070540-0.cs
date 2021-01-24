    using System;
    using System.Collections.Generic;
    
    class Program
    {
    	public static int Main(string[] args)
    	{
    		var numbers = new List<int>();
    		Random rnd = new Random();
    		for (int n = 0; n < 20; n++)
    		{
    			int num = rnd.Next(1000, 9999);
    			for (int i = 0; i < numbers.Count; i++)
    			{
    				if (num == numbers[i])
    				{
    					while (num == numbers[i])
    						num = rnd.Next(1000, 9999);
    					i = -1;
    				}
    			}
    			numbers.Add(num);
    		}
    		// Uncomment if you want sorting
    		// numbers.Sort();
    		// Print numbers so we can check that every entry is unique
    		for (int i = 0; i < numbers.Count; i++)
    			Console.WriteLine("Id: {0}", numbers[i]);
    		return 0;
    	}
    }
