    public static Message Convert(XmlDocument doc)
    {
        Message obj;
        using (TextReader textReader = new StringReader(doc.OuterXml))
        {
            using (XmlTextReader reader = new XmlTextReader(textReader))
            {
                reader.Namespaces = false;
                XmlSerializer serializer = new XmlSerializer(typeof(Message));
                obj = (Message)serializer.Deserialize(reader);
            }
        }
        return obj;
    }
