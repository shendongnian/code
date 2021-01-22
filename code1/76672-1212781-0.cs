    public static void SerializeToXml<T>(T obj, string fileName)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T)); 
        ser.Serialize(fileStream, obj);
        fileStream.Close(); 
        FileStream fileStream = new FileStream(fileName, FileMode.Create); 
    }
    public static T DeserializeFromXml<T>(string xml)
    {
        T result;
        XmlSerializer ser = new XmlSerializer(typeof(T));
        using (TextReader tr = new StringReader(xml))
        {
            result = (T)ser.Deserialize(tr);
        }
        return result;
    }
