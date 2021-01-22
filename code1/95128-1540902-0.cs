    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    class Example
    {
    	static void Main()
    	{
    		List<String> names = new List<String>
    		{
    			"A Lot Like Me",
    			"Adiago For Strings",
    			"Stay Crunchy",
    			"The Foresaken",
    			"Time to Pretend"
    		};
    
    		names.Sort(smartCompare);
    	}
    
    	static Regex smartCompareExpression
    		= new Regex(@"^(?:A|The)\s*",
    			RegexOptions.Compiled |
    			RegexOptions.CultureInvariant |
    			RegexOptions.IgnoreCase);
    
    	static Int32 smartCompare(String x, String y)
    	{
    		x = smartCompareExpression.Replace(x, "");
    		y = smartCompareExpression.Replace(y, "");
    
    		return x.CompareTo(y);
    	}
    }
