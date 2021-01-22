    [Serializable]
    public class FormElement
    {
       [XmlAttribute]
       public string Name {get; set;};
       [XmlAttribute]
       public int Sequence {get; set;};
  
       [XmlAttribute]
       public string Value {get; set;};
       [XmlElement]
       public Validation OnValidate{get; set;}
       [NonSerialized]
       public string UnimportantProperty {get; set;};
    }
