    public static string SerializeObject<T>(T obj)
    {
        try
        {
             string xmlString = null;
             using (MemoryStream memoryStream = new MemoryStream())
             {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                xmlString = UTF8ByteArrayToString(memoryStream.ToArray()); 
                return xmlString;
            }
         }
         catch
         {
             return string.Empty;
         }
    }
