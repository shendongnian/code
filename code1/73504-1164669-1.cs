    StringBuilder builder = new StringBuilder();
    using (XmlWriter writer = XmlWriter.Create(builder))
    {
        writer.WriteStartDocument();
    
        writer.WriteStartElement("BigXml");
        writer.WriteAttributeString("someAttribute", "42");
        writer.WriteString("Some Inner Text");
    
        //Write nodes under BigXml
        writer.WriteStartElement("SomeName");
        writer.WriteEndElement();
    
        writer.WriteEndElement();
    
        writer.WriteEndDocument();
    }
