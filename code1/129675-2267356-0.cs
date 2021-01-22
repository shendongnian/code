    [DataContract]
    public class MyDto
    {
      [DataMember]
      public Keywords keywords { get; set; }
    }
    
    [DataContract]
    public class Keywords
    {
      [DataMember]
      public List<string> anyString { get; set; }
    
      [DataMember]
      public Dictionary<string,string> allString { get; set; }
    
      [DataMember]
      public List<string> exactString { get; set; }
    
      [DataMember]
      public List<string> notString { get; set; }
    
      [DataMember]
      public List<string> highlightString { get; set; }
    }
    
    var dto = new MyDto { Keywords = { allString = {{"a5349f533e3aa3ccbc27de2638da38d6", "olympics"}} };
    
    var json = JsonConvert.SerializeObject(dto);
    var fromJson = JsonConvert.DeserializeObject<MyDto>(json);
