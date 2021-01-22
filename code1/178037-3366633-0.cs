    using(var writer = XmlWriter.Create(stream))
    {
      writer.WriteStartDocument();
      writer.WriteStartElement("dataset");
      writer.WriteElementString("field1", "value");
      writer.WriteElementString("field2", "value");
      writer.WriteElementString("field3", "value");
      writer.WriteEndElement();
      writer.WriteEndDocument();
    }
