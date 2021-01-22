    [DataContract]
    public class MyClass
    {
      [DataMember]
      public string SerializeMe {get;set;}
    
      public string DontSerializeMe {get;set;}
      [DataMember]
      public string SerializeMeToo {get;set;}
    }
