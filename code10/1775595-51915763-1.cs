    XmlSerializer serializer = new XmlSerializer(typeof(List<PersonelInfo>), "sample url ....");
                XmlReaderSettings settings = new XmlReaderSettings();
                using (StringReader textReader = new StringReader(aa))
                {
                    using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                    {
                        var aaa = (List<PersonelInfo>)serializer.Deserialize(xmlReader);
                    }
                }
