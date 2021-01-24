    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var sValue = Convert.ToString(32.548);
    		
    		var normalized = sValue.Where(s => char.IsDigit(s));
    		
    		var charArray = sValue.ToArray();
    		
    		var numArray = normalized.Select(num => char.GetNumericValue(num)).ToList();
    		
    		numArray.ForEach(num => Console.WriteLine(num));
    	}
    }
