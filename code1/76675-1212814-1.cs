    public static void SaveXmlSerialiableElement<T>(this XmlWriter writer, String elementName, T element) where T : IXmlSerializable
    {
       writer.WriteStartElement(elementName);
       writer.WriteAttributeString("TYPE", element.GetType().AssemblyQualifiedName);
       element.WriteXml(writer);
       writer.WriteEndElement();
    }
    
    public static T ReadXmlSerializableElement<T>(this XmlReader reader, String elementName) where T : IXmlSerializable
    {
       reader.ReadToElement(elementName);
         
       Type elementType = Type.GetType(reader.GetAttribute("TYPE"));
       T element = (T)Activator.CreateInstance(elementType);
       element.ReadXml(reader);
       return element;
    }
