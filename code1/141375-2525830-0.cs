    private static string SerializeObject<T>(T source)
    {
        var serializer = new XmlSerializer(typeof(T));
     
        using (var sw = new System.IO.StringWriter())
        using (var writer = new XmlTextWriter(sw))
        {
            serializer.Serialize(writer, source);
            return sw.ToString();
        }
    }
