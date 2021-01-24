            public static string SerializeObject<T>(T dataObject)
            {
                if (dataObject == null)
                    throw new InvalidOperationException("Object is NULL");
                using (StringWriter stringWriter = new StringWriter())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stringWriter, dataObject);
                    return stringWriter.ToString();
                }
            }
            public static T DeserializeObject<T>(string xml)
                 where T : class
            {
                if (string.IsNullOrEmpty(xml))
                    throw new InvalidOperationException("Empty XML ERROR");
                using (var stringReader = new StringReader(xml))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(stringReader);
                }
            }
