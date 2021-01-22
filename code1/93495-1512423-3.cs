    class Util
    {
      public static string SerializeToXml<T>(T o) where T: class
      {
        using (var sw = new StringWriter())
        {
          var ser = new XmlSerializer(typeof(T));
          ser.Serialize(sw, o);
    
          return sw.ToString();
        }
      }
    
      public static T DeserializeFromXml<T>(string xml) where T: class
      {
        using (var sr = new StringReader(xml))
        {
          var ser = new XmlSerializer(typeof(T))
          return ser.Deserialize(sr) as T;
        }
      }
    }
