    //@eglasius example, still using data.xml from OP
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    class loadXMLToLINQ2
    {
    	static void Main( )
    	{
    		StringBuilder result = new StringBuilder(); //needed for result below
    		XDocument xdoc = XDocument.Load(@"c:\\deg\\data.xml"); //you'll have to edit your path
    		var lv1s = xdoc.Root.Descendants("level1"); 
    		var lvs = lv1s.SelectMany(l=>
    			 new string[]{ l.Attribute("name").Value }
    			 .Union(
    				 l.Descendants("level2")
    				 .Select(l2=>"   " + l2.Attribute("name").Value)
    			  )
    			);
    		foreach (var lv in lvs)
    		{
    		   result.AppendLine(lv);
    		}
    		Console.WriteLine(result);//added this so you could see the result
    	}
    }
