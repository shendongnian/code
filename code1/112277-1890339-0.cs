    void Main(string[] args)
    {
	  XDocument xml = XDocument.Parse("XML CONTENTS HERE")
	  XNamespace ns = "http://www.namespace.com/ns";
	
	  // Pull out the categories
	  var propertyGroups = 
		from pg in xml.Descendants(ns + "propertyGroup")
		select new 
		{
			Name = pg.Attribute("name").Value,
			Pairs = from p in pg.Descendants(ns + "property")
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
