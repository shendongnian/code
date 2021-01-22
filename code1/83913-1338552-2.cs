    using System;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		XNamespace ci = "http://somewhere.com";
    		XNamespace ca = "http://somewhereelse.com";
    
    		XElement element = new XElement("root",
    			new XAttribute(XNamespace.Xmlns + "ci", ci),
    			new XAttribute(XNamespace.Xmlns + "ca", ca),
    				new XElement(ci + "field1", "test"),
    				new XElement(ca + "field2", "another test"));
    	}
    }
