    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class MainClass
    {
    	public static void Main (string[] args)
    	{
    		Regex ry = new Regex
                  (@"([A-Z][a-z]+|[A-Z]+[A-Z]|[A-Z]|[^A-Za-z]+[^A-Za-z])", 
                  RegexOptions.RightToLeft);
    		
    							
    		string[] tests = {
    		"AutomaticTrackingSystem",
    		"XMLEditor",
    		"AnXMLAndXSLT2.0Tool",
    		"NumberOfABCDThings",
    		"AGoodMan",
    		"CodeOfAGoodMan"
    		};
    		
    		
    		foreach(string t in tests)
    		{
    			Console.WriteLine("\n\n{0} -- {1}", t, ry.Replace(t, " $1"));	
    		}
    		
    	}
    	
    	
    }
