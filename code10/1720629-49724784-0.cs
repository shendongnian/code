    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var goodList = new List<string>{"1", "12", "12 34","12 a 34", "1a", "54b", "32 c", "43-23", "45c/34", "45/34d", "67 / 345", "23a / 56", "12 / 56b"};
    		var badList = new List<string>{"1 3 5", "34 a a", "34b s", "234a/a", "34b 456s", "34b/456s", "34b / 456s"};
    		var pattern = @"^\d+\s?(?:\W\s?\d+(?:\s?[a-z])?|(?:\d+\s?)?[a-z]?|[a-z]\s?\W\s?\d+)$";
    		var regex = new Regex(pattern);
    		Console.WriteLine("Good list");
    		Console.WriteLine("-------------");
    		foreach (var item in goodList)
    		{
    			Console.WriteLine(string.Format("{0} - {1}", regex.IsMatch(item), item));
    		}
    
    		Console.WriteLine();
    		Console.WriteLine("Bad list");
    		Console.WriteLine("-------------");
    		foreach (var item in badList)
    		{
    			Console.WriteLine(string.Format("{0} - {1}", regex.IsMatch(item), item));
    		}
    	}
    }
