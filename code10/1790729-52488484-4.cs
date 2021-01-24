    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string pattern = @"([""'])(?:(?=(\\?))\2.)*?\1";
    		List<string> lines = new List<string>(); 
    		lines.Add("4121,6383,0,,,TRUE");
    		lines.Add("4122,6384,0,\"20,000 BONUS POINTS\",,TRUE");
    		lines.Add("4123,6385,,,,");
    		lines.Add("4124,6386,0,,,TRUE");
    		lines.Add("4125,6387,0,,,TRUE");
    		lines.Add("4126,6388,0,,,TRUE");
    		lines.Add("4127,6389,0,,,TRUE");
    		lines.Add("4128,6390,0,,,TRUE");
            
    		StringBuilder sb = new StringBuilder();
    		foreach (var line in lines)
    		{
    			sb.Append(Regex.Replace(line, pattern, m => m.Value.Replace(",", ""))+"\n");
    		}			
    		Console.WriteLine(sb.ToString());
    	}
    }
