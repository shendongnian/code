    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.OmitXmlDeclaration = true;
    XmlWriter writer = XmlWriter.Create(Console.Out, settings);
    
    writer.WriteStartElement("ROOT");
    
    writer.WriteStartElement("Unit");
    writer.WriteAttributeString("UnitName", "Unit XYZ");
    writer.WriteEndElement();
    
    writer.WriteStartElement("Scheds");
    writer.WriteAttributeString("Qty", "5");
    writer.WriteAttributeString("ProdId", "214");
    writer.WriteAttributeString("Comments", "Need by 1/25");
    writer.WriteEndElement();
    
    // Write the close tag for the root element.
    writer.WriteEndElement();
    writer.Close(); 
 
