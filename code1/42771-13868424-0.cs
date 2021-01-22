    //bendewey's example using data.xml from OP
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    class loadXMLToLINQ1
    {
    	static void Main( )
    	{
    		//Load xml
    		XDocument xdoc = XDocument.Load(@"c:\\data.xml"); //you'll have to edit your path
    
    		//Run query
    		var lv1s = from lv1 in xdoc.Descendants("level1")
    		   select new 
    		   { 
    			   Header = lv1.Attribute("name").Value,
    			   Children = lv1.Descendants("level2")
    			};
    
    		StringBuilder result = new StringBuilder(); //had to add this to make the result work
    		//Loop through results
    		foreach (var lv1 in lv1s)
    		{
    			result.AppendLine("  " + lv1.Header);
    			foreach(var lv2 in lv1.Children)
    			result.AppendLine("    " + lv2.Attribute("name").Value);
    		}
    		Console.WriteLine(result.ToString()); //added this so you could see the output on the console
    	}
    }
