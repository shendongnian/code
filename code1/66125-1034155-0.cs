    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
    	static void Main()
    	{
    		String foo = "google.com 220 USD 3d 19h";
    		Regex regex = new Regex(@"(.com)", RegexOptions.IgnoreCase);
    		Match match = regex.Match(foo);
    
    		if (match.Success)
    			Console.WriteLine(match.Groups[1].Value);
    	}
    }
