    public class XmlHelper<T>
    {
     public T Deserialize(string xml)
      {
        XmlSerializer xs = new XmlSerializer(typeof(T));
        Byte[] byteArray = new UTF8Encoding().GetBytes(xml);
        MemoryStream memoryStream = new MemoryStream(byteArray);
        XmlTextReader xmlTextReader = new XmlTextReader(memoryStream);
        T retObj = (T)xs.Deserialize(xmlTextReader);
        return retObj;
      }
    }
