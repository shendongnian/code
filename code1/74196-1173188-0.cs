    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		String xml = @"<Root><Value></Value></Root>";
    
    		var elements = XDocument.Parse(xml)
    			.Descendants("Value")
    			.Select(e => e.Value);
    	}
    }
