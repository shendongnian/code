    [DataContract]
    public struct ToSerialize
    {
      public ToSerialize(string a)
      {
        PropertyToSerialize = "a";
      }
      [DataMember]
      public string PropertyToSerialize { get; }
    }
