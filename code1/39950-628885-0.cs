    public static string SerializeObject<T>(T obj)
    {
          string xmlString = null;
    	  using(MemoryStream memoryStream = new MemoryStream())
    	  {
    		using(XmlSerializer xs = new XmlSerializer(typeof(T)))
    		{
          		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
          		xs.Serialize(xmlTextWriter, obj);
          		memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
          		xmlString = UTF8ByteArrayToString(memoryStream.ToArray());      
    		}
    	  }
    	  return xmlString;
    }
    
    public static T DeserializeObject<T>(string xml)
    {
       XmlSerializer xs = new XmlSerializer(typeof(T));
       MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
       XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
       return (T)xs.Deserialize(memoryStream);
    }
