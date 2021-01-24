    public static YourClass LoadFromXMLString(string xmlText)
    {
        var stringReader = new System.IO.StringReader(xmlText);
        var serializer = new XmlSerializer(typeof(YourClass ));
        return serializer.Deserialize(stringReader) as YourClass ;
    }
