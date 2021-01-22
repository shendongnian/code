    public static void WriteFullElementString(this XmlTextWriter writer,
                                              string localName, 
                                              string value)
    {
        writer.WriteStartElement(localName);
        writer.WriteString(value);
        writer.WriteFullEndElement();
    }
