    [Serializable, XmlRoot(namespace="http://example.com/eg1")]
    public class MyClass {
      [XmlElement(ElementName = "DataString")]
      public string MyString { get; set; }
    }
