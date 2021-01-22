    XmlTextWriter writer = new XmlTextWriter(...);
    writer.Formatting = Formatting.Indented;
    writer.Indentation = 1;
    writer.IndentChar = '\t';
    
    writer.WriteStartElement("root");
    
    // people is some collection for the sake of an example
    for (int index = 0; index < people.Count; index++)
    {
    	writer.WriteStartElement("Person");
    
    	// some node condition to turn off formatting
    	if (index == 1 || index == 3)
    	{
    		writer.Formatting = Formatting.None;
    	}
    
    	// write out the node and its elements etc.
    	writer.WriteAttributeString("...", people[index].SomeProperty);
    	writer.WriteElementString("FirstName", people[index].FirstName);
    
    	writer.WriteEndElement();
    	
    	// reset formatting to indented
    	writer.Formatting = Formatting.Indented;
    }
    
    writer.WriteEndElement();
    writer.Flush();
