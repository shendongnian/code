    private void ValidateSubnode(XmlNode node, XmlSchema schema)
    {
      XmlTextReader reader = new XmlTextReader(node.OuterXml, XmlNodeType.Element, null);
    
      XmlReaderSettings settings = new XmlReaderSettings();
      settings.ConformanceLevel = ConformanceLevel.Fragment;
      settings.Schemas.Add(schema);
      settings.ValidationType = ValidationType.Schema;
      settings.ValidationEventHandler += new ValidationEventHandler(XSDValidationEventHandler);
    
      XmlReader validationReader = XmlReader.Create(reader, settings);
      
      while (validationReader.Read())
      {
      }
    }
    private void XSDValidationEventHandler(object sender, ValidationEventArgs args)
    {
      errors.AppendFormat("XSD - Severity {0} - {1}", 
                          args.Severity.ToString(), args.Message);
    }
