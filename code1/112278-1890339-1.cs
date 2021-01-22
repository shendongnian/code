    void Main(string[] args)
    {
	  XDocument xml = XDocument.Parse("XML CONTENTS HERE")
	  XNamespace ns = "http://www.namespace.com/ns";
	
	  // Pull out the property Groups
	  var propertyGroups = 
		from pg in xml.Descendants(ns + "propertyGroup")
                //Return a new, anonymous object to represent the xml propertyGroup
		select new 
		{
			Name = pg.Attribute("name").Value,
                        //Pairs will be a collection of all properties in the group
			Pairs = from p in pg.Descendants(ns + "property")
                                //Nested anonymous type
				select new
				{
					Key = p.Attribute("key").Value,
					Value = p.Attribute("value").Value
				}
		};
	  foreach (var propertyGroup in propertyGroups)
	  {
		Console.WriteLine("[" + propertyGroup.Name + "]");
		foreach (var pair in propertyGroup.Pairs)
		{
			Console.WriteLine(pair.Key + "=" + pair.Value);
		}
	  }
    }
