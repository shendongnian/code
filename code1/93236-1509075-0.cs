    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ProhibitDtd = false;
    settings.ValidationType = ValidationType.DTD;
    
    settings.ValidationEventHandler += new ValidationEventHandler(validationError);        
    
    XmlSchemaSet schemas = new XmlSchemaSet();
    schemas.Add(null, lblDTDPath.Text);
    settings.Schemas = schemas;
    XmlReader reader = XmlReader.Create(lblXmlPath.Text, settings);
    
    while (reader.Read())
    { 
              // empty by now
    }
    reader.Close();
