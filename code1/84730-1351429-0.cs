    using System;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		String xml = @"<Action 
    				id=""SignIn"" 
    				description=""nothing to say here"" 
    				title=""hello""/>";
    
    		String id = XElement.Parse(xml)
    			.Attribute("id").Value;
    	}
    }
