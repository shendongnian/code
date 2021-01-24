    using System;
    using System.Text.RegularExpressions;
					
    public class Program  {
    	public static void Main() {
		    string input = "29/10/2018 14:50:09402325 671";
    		Regex rx = new Regex(@"(.*):([^:]+)",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
		
		    MatchCollection matches = rx.Matches(input);
            if ( matches.Count >= 1 ) {
    		    var m = matches[0].Groups;
	    	    Console.WriteLine(m[1]);
		        Console.WriteLine(m[2]);		
            }
	    }
    }
