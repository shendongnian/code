    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		var map = new Dictionary<string, object>()
    		{
    			{ "Param1", true },
    			{ "Param2", "\"False\"" },
    			{ "Param3", 123 },
    			{ "Param4", "\"1234\"" },
    		};
    		
    		var script = " I have Param1 and Param2 and Param3 and Param4 ";
    		MatchCollection matches = Regex.Matches(script, "Param\\d+");
    		foreach (Match match in matches)
    		{
    			object val = map[match.Value];
    			script = script.Replace(match.Value, val is bool ? val.ToString().ToLower() : val.ToString());
    		}
    		
    		Console.WriteLine(script);
    	}
    }
