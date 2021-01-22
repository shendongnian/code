    [Serializable, XmlRoot, DataContract]
    public class Cat
    {
      [XmlElement]
      [DataMember]
      public string Name { get; set; }
      [XmlElement]
      [DataMember]
      public string Breed { get; set; }
    }
