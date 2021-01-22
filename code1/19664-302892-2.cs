    public byte[] SerializeToByteArray(object object2Serialize) {
           using(MemoryStream stream = new MemoryStream()) {
              XmlSerializer xmlSerializer = new XmlSerializer(object2Serialize.GetType());
              xmlSerializer.Serialize(stream, object2Serialize);
              return stream.ToArray();
           }
    }
    public string SerializeToString(object object2Serialize) {
       byte[] bytes = SerializeToByteArray(object2Serialize);
       return Text.UTF8Encoding.GetString(bytes);
    }
 
    
