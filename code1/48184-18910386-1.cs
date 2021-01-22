    using System;
    
    class Program
    {
        static void Main()
        {
    	// Create four-item tuple; use var implicit type.
    	var tuple = new Tuple<string, string[], int, int[]>("perl",
    	    new string[] { "java", "c#" },
    	    1,
    	    new int[] { 2, 3 });
    	// Pass tuple as argument.
    	M(tuple);
        }
    
        static void M(Tuple<string, string[], int, int[]> tuple)
        {
    	// Evaluate the tuple's items.
    	Console.WriteLine(tuple.Item1);
    	foreach (string value in tuple.Item2)
    	{
    	    Console.WriteLine(value);
    	}
    	Console.WriteLine(tuple.Item3);
    	foreach (int value in tuple.Item4)
    	{
    	    Console.WriteLine(value);
    	}
        }
    }
