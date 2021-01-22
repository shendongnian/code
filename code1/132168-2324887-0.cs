    public static T ReadFromXML<T>(this T ignored, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (TextReader reader = new StreamReader(fileName, Encoding.UTF8))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
