    [XmlRoot(Namespace="Data/Main")]
    public class Request {
      [XmlElement(Namespace = "Data/All")]
      public int Id { get; set; }
      [XmlElement(Namespace="Data/All")]
      public Name Name {get;set;}
    }
    
    [XmlType(Namespace="Data/All")]
    public class Name {
      [XmlAttribute("test")]
      public bool Test {get;set;}
      public string FirstName {get;set;}
      public string LastName {get;set;}
    }
