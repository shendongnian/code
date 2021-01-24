     [DataContract]
     class MyObject
     {
          [DataMember]
          int SomeID { get; set;}
          [DataMember]
          string SomeName { get; set;}
          [DataMember]
          List<AnotherObjectContainingIDAndString> { get; set;}
     }   
