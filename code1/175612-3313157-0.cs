        public static  string SerializeObject<T>(T obj)
        {
           if (!typeof(T).IsSerializable)
           {
               throw new ArgumentException("type is not serializable");
           }
           string xmlString = string.Empty;
           MemoryStream memoryStream = new MemoryStream();
           
           try
           {
              XmlSerializer xs = new XmlSerializer(typeof(T));
              XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
              xs.Serialize(xmlTextWriter, obj);
              xmlString = UTF8ByteArrayToString(memoryStream.ToArray());      
           }
           catch // something useful here
           {
              // Do something useful here
           }
           finally
           {
              // Dispose of what you want here
           }
           return xmlString;
        }
