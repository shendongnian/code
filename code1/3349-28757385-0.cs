    using (MemoryStream memStream = new MemoryStream())
                {
                    memStream.Write(Encoding.UTF8.GetBytes(xmlBody), 0, xmlBody.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    using (StreamReader reader = new StreamReader(memStream))
                    {
                        // xml reader setting.
                        XmlReaderSettings xmlReaderSettings = new XmlReaderSettings()
                        {
                            IgnoreComments = true,
                            IgnoreWhitespace = true,
                        };
                        // xml reader create.
                        using (XmlReader xmlReader = XmlReader.Create(reader, xmlReaderSettings))
                        {                           
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LoginInfo));
                            myObject = (LoginInfo)xmlSerializer.Deserialize(xmlReader);
                        }
                    }         
                }
