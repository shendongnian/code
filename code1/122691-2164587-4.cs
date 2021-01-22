    [XmlType("Root", Namespace = "http://example.com/Root")]
    [XmlRoot(Namespace = "http://example.com/Root.xsd", ElementName = "Root", IsNullable = false)]
    public class Root {
      [XmlElement("Something")] 
      public Something Something { get; set; }
    }
    public class Something {
      [XmlElement("SomethingElse")]
      public SomethingElse SomethingElse { get; set; }
    }
    public class SomethingElse {
      [XmlText]
      public string Text { get; set; }
    }
