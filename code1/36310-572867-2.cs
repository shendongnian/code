    XmlDocument x = new XmlDocument();
    x.LoadXml(XmlSource);
    
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.CloseInput = true;     
    settings.ValidationEventHandler += Handler;
    
    settings.ValidationType = ValidationType.Schema;
    settings.Schemas.Add(null, ExtendedTreeViewSchema);
    settings.ValidationFlags =
         XmlSchemaValidationFlags.ReportValidationWarnings |
    XmlSchemaValidationFlags.ProcessIdentityConstraints |
    XmlSchemaValidationFlags.ProcessInlineSchema |
    XmlSchemaValidationFlags.ProcessSchemaLocation ;
    
    StringReader r = new StringReader(XmlSource);
    
    using (XmlReader validatingReader = XmlReader.Create(r, settings)) {
            while (validatingReader.Read()) { /* just loop through document */ }
    }
    
