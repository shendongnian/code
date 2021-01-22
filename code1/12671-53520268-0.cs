    using System;
    using System.Linq;
    using System.Text;
    
    public static class StringExtension
    {
    	public static string StripSpaces(this string s)
    	{
    		return s.Aggregate(new StringBuilder(), (acc, c) =>
    		{
    			if (c != ' ' || acc.Length > 0 && acc[acc.Length-1] != ' ')
    				acc.Append(c);
    			return acc;
    		}).ToString();
    	}
    
    	public static void Main()
    	{
    		Console.WriteLine("\"" + StringExtension.StripSpaces("1   Hello       World  2   ") + "\"");
    	}
    }
