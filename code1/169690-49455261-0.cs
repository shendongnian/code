    [DataContract]
    [knownType(typeof(Person))]
    public class KeyValue
    {
      [DataMember]
      public string key {get; set;}
     
      [DataMember]
      public string value {get; set;}
    
      // rest of the code
    }
