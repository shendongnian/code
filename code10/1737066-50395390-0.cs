    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		string input = "f20s30t";
    		string pattern = "([fst]|[0-9]+[fst])";
    		string[] substrings = Regex.Split(input, pattern);
    		foreach (string match in substrings)
    		{
    			Console.WriteLine("'{0}'", match);
    		}
    	}
    }
    //
    //f
    //
    //20s
    //
    //30t
 
