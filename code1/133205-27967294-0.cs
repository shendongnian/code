        public static T DeserializeFromXmlString<T>(string xmlString)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlString))
            {
                return (T) serializer.Deserialize(reader);
            }
        }
