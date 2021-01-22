    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
    	static void Main()
    	{
    		String input = @" Compile complete -- 1 errors, 213 warnings
    
    				 6>Process_Math - 3 error(s), 1 warning(s)
    				 24>Process_Math - 1 error(s), 0 warning(s)";
    
    		Regex regex = new Regex(@"(\d+)\serrors?,\s(\d+)\swarnings?",
    			RegexOptions.Compiled |
    			RegexOptions.CultureInvariant |
    			RegexOptions.IgnoreCase |
    			RegexOptions.Multiline);
    
    		Match match = regex.Match(input);
    
    		if (match.Success)
    		{
    			Console.WriteLine("errors: " + match.Groups[1].Value);
    			Console.WriteLine("warnings: " + match.Groups[2].Value);
    		}
    	}
    }
