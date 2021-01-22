    public static class Utility
    {
           public static void ToXml<T>(T src, string rootName, string fileName) where T : class, new()
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
                XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8);
                serializer.Serialize(writer, src);
                writer.Flush();
                writer.Close();
            }
    }
