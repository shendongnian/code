    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
    	static void Main()
    	{
    		String sample = "hello-world-";
    		Regex regex = new Regex("-(?<test>[^-]*)-");
    
    		Match match = regex.Match(sample);
    
    		if (match.Success)
    		{
    			Console.WriteLine(match.Groups["test"].Value);
    		}
    	}
    }
