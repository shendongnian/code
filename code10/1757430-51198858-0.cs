    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int[] intArray = { 5, 6, 2, 4 };
    		var result = string.Concat(intArray);
    
    		Console.WriteLine(result);
    		try {
    			int resultNumber = int.Parse(result);
    		}
    		catch(OverflowException) {
    			long resultBigNumber = long.Parse(result);
    		}
    	}
    }
