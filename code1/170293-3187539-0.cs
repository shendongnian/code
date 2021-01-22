            public static T FromXml<T>(String xml)
        {
            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        // String passed is not XML, return default
                        return default(T);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
