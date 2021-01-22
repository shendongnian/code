    public T ConvertXml<T>(string xml)
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(new StringReader(xml));
    }
