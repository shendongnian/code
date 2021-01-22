        public T FromXml<T>(string xml)
        {
            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
                catch (InvalidOperationException)
                {
                    // string passed is not XML, return default
                    return default(T);
                }
            }
        }
