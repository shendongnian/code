    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class MainClass
    {
    	public static void Main (string[] args)
    	{
    		var rx = new Regex
                    (@"([a-z]+[A-Z]|[A-Z][A-Z]+|[A-Z]|[^A-Za-z][^A-Za-z]+)");
    							
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
    			string y = Reverse(t);
    			string x = Reverse( rx.Replace(y, @" $1") );
    			Console.WriteLine("\n\n{0} -- {1}",y,x);	
    		}
    		
    	}
    	
    	static string Reverse(string s)
    	{
    		var ca = s.ToCharArray();
    		Array.Reverse(ca);
    		string t = new string(ca);
    		return t;
    	}
    	
    }
