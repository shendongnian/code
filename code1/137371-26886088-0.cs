            string Serialise<T>(T serialisableObject)
            {
                var xmlSerializer = new XmlSerializer(serialisableObject.GetType());
    
                using (var ms = new MemoryStream())
                {
                    using (var xw = XmlWriter.Create(ms, 
                        new XmlWriterSettings()
                            {
                                Encoding = new UTF8Encoding(false),
                                Indent = true,
                                NewLineOnAttributes = true,
                            }))
                    {
                        xmlSerializer.Serialize(xw,serialisableObject);
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
