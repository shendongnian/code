    //Read in the schema document
    using (XmlReader schemaReader = XmlReader.Create("schema.xsd"))
    {
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        //add the schema to the schema set
        schemaSet.Add(XmlSchema.Read(schemaReader, 
		new ValidationEventHandler(
			delegate(Object sender, ValidationEventArgs e)
			{
			}    
		)));
	  
        //Load and validate against the programmatic schema set
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Schemas = schemaSet;
        xmlDocument.Load("something.xml");
        xmlDocument.Validate(new ValidationEventHandler(
            delegate(Object sender, ValidationEventArgs e)
            {
                //Report or respond to the error/warning
            }
        ));	
     }
