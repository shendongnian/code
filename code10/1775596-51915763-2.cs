    XmlSerializer serializer = new XmlSerializer(typeof(List<PersonelInfo>), "sample url ....");
                XmlReaderSettings settings = new XmlReaderSettings();
                using (StringReader textReader = new StringReader(await responseMessageGetDetailsUser.Content.ReadAsStringAsync()))
                {
                    using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
                    {
                        var data = (List<PersonelInfo>)serializer.Deserialize(xmlReader);
                    }
                }
