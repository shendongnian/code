    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Example
    {
    	static void Main()
    	{
    		var result = from person in XElement.Load("Example.xml")
    				     .Elements("Person")
    			     let fields = person.Descendants("Field")
    			     select new {
    				     Id = person.Attribute("Id").Value,
    				     Fields = fields.Select(f => new {
    					     Id = f.Attribute("FieldId").Value,
    					     Value = f.Attribute("Value").Value
    				     })
    			     };
    	}
    }
