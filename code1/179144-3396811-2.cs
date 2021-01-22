    public static String ToXml<T>(T instance)
    {
        using (var output = new StringWriter(new StringBuilder()))
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(output, instance);
            return output.ToString();
        }
    }
