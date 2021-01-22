    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication6
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			var unsortedListOfStringsAsInts = new List<string> {"1234", "2345", "7", "9"};
    			var sortedListOfInts = unsortedListOfStringsAsInts.Select(x => int.Parse(x)).OrderBy(x => x).ToList();
    
    			foreach (var i in sortedListOfInts)
    				Console.WriteLine(i);
    		}
    	}
    }
