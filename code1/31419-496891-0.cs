    StringBuilder sb = new StringBuilder();
    XmlWriter writer = XmlWriter.Create(sb, settings);
    
    writer.WriteStartDocument();
    writer.WriteStartElement("People");
    
    writer.WriteStartElement("Person");
    writer.WriteAttributeString("Name", "Nick");
    writer.WriteEndElement();
    
    writer.WriteStartElement("Person");
    writer.WriteStartAttribute("Name");
    writer.WriteValue("Nick");
    writer.WriteEndAttribute();
    writer.WriteEndElement();
    
    writer.WriteEndElement();
    writer.WriteEndDocument();
    
    writer.Flush();
    
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(sb.ToString());
    return xmlDocument;
