    using (XmlWriter writer = XmlWriter.Create("YourFilePath"))
    {
        writer.WriteStartDocument();
    
        writer.WriteStartElement("Root");
    
        for (int i = 0; i < 1000000; i++) //Write one million nodes.
        {
            writer.WriteStartElement("Root");
            writer.WriteAttributeString("value", "Value #" + i.ToString());
            writer.WriteString("Inner Text #" + i.ToString());
            writer.WriteStartElement("Root");
        }
        writer.WriteEndElement();
    
        writer.WriteEndElement();
    
        writer.WriteEndDocument();
    }
