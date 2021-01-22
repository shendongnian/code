    public static string SerializeObject<T>(T obj) 
    { 
       try 
       { 
          using (MemoryStream ms = new MemoryStream()) 
          {
            XmlSerializer xs = new XmlSerializer(typeof(T)); 
            XmlTextWriter xwriter = new XmlTextWriter(ms, Encoding.UTF8); 
            xs.Serialize(xwriter, obj); 
            return UTF8ByteArrayToString(ms.ToArray());
          }
       } 
       catch 
       { 
          return string.Empty; 
       } 
    } 
