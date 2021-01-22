    // Result will be an XElement, 
    // or null if the command with the specified attribute is not found
    var result = 
        doc.Elements("command")
        // Note the extra condition below
    	.SingleOrDefault( x => x.Attribute("name")!=null && x.Attribute("name").Value == name)
    	
    if(result!=null)
    {
        // results.Elements() gives IEnumerable<XElement>
        foreach(var cvar in results.Elements("cvar"))
        {
            var cvarName = cvar.Attribute("name").Value;
            var cvarValue = Convert.ToBoolean( cvar.Attribute("value").Value );
        }
    }
