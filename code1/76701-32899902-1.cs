    [System.Xml.Serialization.XmlArray] //This is the part that makes it work
    List<object> serializableList = new List<object>();
    
    XmlSerializer xmlSerializer = new XmlSerializer(serializableList.GetType());
    
    serializableList.Add(PersonList);
    
    using (StreamWriter streamWriter = System.IO.File.CreateText(fileName))
    {
        xmlSerializer.Serialize(streamWriter, serializableList);
    }
