    static string SerializeXml<T>(T obj) where T : class
    {
        if (obj == null) return null;
        StringWriter sw = new StringWriter();
        using (XmlWriter xw = XmlWriter.Create(sw))
        {
            new XmlSerializer(typeof(T))
                .Serialize(xw, obj);
        }
        return sw.ToString();
    }
    static T DeserializeXml<T>(string xml) where T : class
    {
        if (xml == null) return null;
        using (XmlReader xr = XmlReader.Create(new StringReader(xml)))
        {
            return (T)new XmlSerializer(typeof(T))
                .Deserialize(xr);
        }
    }
