    class Util
    {
      public static string SerializeToXml<T>(T o)
      {
        using (var ser = new XmlSerializer(typeof(T)))
        using (var sw = new StringWriter())
        {
          ser.Serialize(sw, o);
    
          return sw.ToString();
        }
      }
    
      public static T DeserializeFromXml<T>(string xml)
      {
        using (var ser = new XmlSerializer(typeof(T)))
        using (var sr = new StringReader(xml))
        {
          return ser.Deserialize(sr) as T;
        }
      }
    }
