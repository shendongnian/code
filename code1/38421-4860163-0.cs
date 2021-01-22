    private void SerializeParams<T>(XDocument doc, List<T> paramList)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(paramList.GetType());
            
            System.Xml.XmlWriter writer = doc.CreateWriter();
            serializer.Serialize(writer, paramList);
            writer.Close();           
        }
    private List<T> DeserializeParams<T>(XDocument doc)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
                      
            System.Xml.XmlReader reader = doc.CreateReader();
            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();
            return result;
        }
