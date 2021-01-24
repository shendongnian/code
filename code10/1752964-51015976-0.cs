    using System;
    using System.Linq;
					
    public class Program
    {
	    public static void Main()
    	{
    		Console.WriteLine(FindIndexPair("Hello\r\nWorld", 0)); // (1, 1)
    		Console.WriteLine(FindIndexPair("Hello\r\nWorld", 4)); // (1, 5)
    		Console.WriteLine(FindIndexPair("Hello\r\nWorld", 7)); // (2, 1)
    		Console.WriteLine(FindIndexPair("Hello\r\nWorld", 11)); // (2, 5)
		
    		Console.WriteLine(FindIndexPair("Hello\nWorld", 0)); // (1, 1)
    		Console.WriteLine(FindIndexPair("Hello\nWorld", 4)); // (1, 5)
    		Console.WriteLine(FindIndexPair("Hello\nWorld", 6)); // (2, 1)
    		Console.WriteLine(FindIndexPair("Hello\nWorld", 10)); // (2, 5)
    	}
	
    	public static Tuple<int, int> FindIndexPair(string val, int index)
    	{
     		var upToIndex = val.Substring(0, index + 1);
    		var lines = upToIndex.Split('\n');
    		var lineNumber = lines.Count();
    		var columnNumber = lines.Last().Length;
    		return Tuple.Create(lineNumber, columnNumber);
    	}
    }
