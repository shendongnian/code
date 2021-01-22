    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
    	static void Main()
    	{
    		Regex regex = new Regex(@"(\d+)$", 
    			RegexOptions.Compiled | 
    			RegexOptions.CultureInvariant);
    		Match match = regex.Match("_1_12");
    
    		if (match.Success)
    			Console.WriteLine(match.Groups[1].Value);
    	}
    }
