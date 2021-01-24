    public static void Serialize<T>(T objectToSerialize, string path)
      where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (var writer = new StreamWriter(path))
        {
            serializer.Serialize(writer, objectToSerialize);
        }
    }
        
