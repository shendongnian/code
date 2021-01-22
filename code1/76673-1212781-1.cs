    public static void SerializeToXml<T>(T obj, string fileName)
    {
        using (var fileStream = new FileStream(fileName, FileMode.Create))
        { 
            var ser = new XmlSerializer(typeof(T)); 
            ser.Serialize(fileStream, obj);
        }
    }
    public static T DeserializeFromXml<T>(string xml)
    {
        T result;
        var ser = new XmlSerializer(typeof(T));
        using (var tr = new StringReader(xml))
        {
            result = (T)ser.Deserialize(tr);
        }
        return result;
    }
