    public static void SaveXmlSerialiazbleCollection<T>(this XmlWriter writer, String collectionName, String elementName, IEnumerable<T> items) where T : IXmlSerializable
    {
       writer.WriteStartElement(collectionName);
       foreach (T item in items)
       {
          writer.WriteStartElement(elementName);
          writer.WriteAttributeString("TYPE", item.GetType().AssemblyQualifiedName);
          item.WriteXml(writer);
          writer.WriteEndElement();
       }
       writer.WriteEndElement();
    }
