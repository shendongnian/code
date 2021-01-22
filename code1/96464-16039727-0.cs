    public static T DeserializeFromXml<T>(string xml)
            {
                T result;
                XmlSerializerFactory serializerFactory = new XmlSerializerFactory();
                XmlSerializer serializer =serializerFactory.CreateSerializer(typeof(T));
    
                using (StringReader sr3 = new StringReader(xml))
                {
                    XmlReaderSettings settings = new XmlReaderSettings()
                    {
                        CheckCharacters = false // default value is true;
                    };
    
                    using (XmlReader xr3 = XmlTextReader.Create(sr3, settings))
                    {
                        result = (T)serializer.Deserialize(xr3);
                    }
                }
    
                return result;
            }
