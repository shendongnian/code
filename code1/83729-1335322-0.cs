    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
    	static void Main()
    	{
    		String input = "Sandviksveien 184, 1300 Sandvika";
    
    		Regex regex = new Regex(@",\s(\d{4})",
    			RegexOptions.Compiled |
    			RegexOptions.CultureInvariant);
    
    		Match match = regex.Match(input);
    
    		if (match.Success)
    			Console.WriteLine(match.Groups[1].Value);
    	}
    }
