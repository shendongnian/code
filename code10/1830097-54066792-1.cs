    [DataContract]
    public struct ToSerialize
    {
      public ToSerialize(string a)
      {
        backingField = "a";
      }
      public string PropertyToSerialize => backingField;
      [DataMember]
      string backingField;
    }
