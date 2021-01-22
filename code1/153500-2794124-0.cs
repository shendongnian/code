    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Example
    {
    	static void Main()
    	{
    		String xml = @"<test>
    				<test1>test1 value</test1>
                   			</test>";
    
    		var test = XElement.Parse(xml)
    				.Descendants("test1")
    				.First()
    				.Value;
    
    		Console.WriteLine(test);
    	}
    }
