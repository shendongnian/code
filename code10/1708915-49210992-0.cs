    public static class CustomServiceStackXmlFormat
    {
        public static string Format = "application/xml";
        public static void Serialize(IRequest req, object response, Stream stream)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(response.GetType());
            xmlSerializer.Serialize(stream, response);
        }
        public static object Deserialize(Type type, Stream stream)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type.GetType());
            var obj = ((Type)xmlSerializer.Deserialize(stream));
            return obj;
        }
    }
