    class Util
    {
      public static string SerializeToXml<T>(T o)
      {
        var ser = new XmlSerializer(typeof(T));
        var sw = new StringWriter();
    
        ser.Serialize(sw, o);
    
        return sw.ToString();
      }
    
      public static T DeserializeFromXml<T>(string xml)
      {
        var ser = new XmlSerializer(typeof(T));
        var sr = new StringReader(xml);
    
        return ser.Deserialize(sr) as T;
      }
    }
