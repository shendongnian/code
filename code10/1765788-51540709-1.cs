    XDocument doc = XDocument.Load("Le.xml");
    var result = from el in doc.Descendants(abc + "ABC")
                               .Elements(def + "DEF")
                               .Descendants("Element")
    			 where el.Attribute(abc + "type") != null &&
    				   (string)el.Attribute(abc + "type") == "def:XYZ"
    			 select el;
    // 	             select new { 
    // 				    Id = (int)el.Attribute(abc+"id"),
    // 					Name = (string)el.Attribute("name")
    // 				 };
    foreach (var item in result)
    {
    	foreach (var element in item.Attributes())
    	{
    		Console.WriteLine($"{element.Name}={element.Value}");
    	}
    	Console.WriteLine("------------");
    }
