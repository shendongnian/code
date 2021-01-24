    public static class XmlHelper
    {
        public static T ParseXmlFile<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(filePath))
            {
                T configuration = (T)serializer.Deserialize(reader);
                return configuration;
            }
        }
    }
