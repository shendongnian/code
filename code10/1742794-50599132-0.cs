    [XmlRoot("Request", Namespace = "com/user/service/core/services/v1")]
    public class Request
    {
      [XmlAttribute]
      public string ProductId { get; set; }
      [XmlElement("Name")]
      public string Name { get; set; }
      [XmlElement("CustomerInfo")]
      public CustomerInfo CustomerInfo = new CustomerInfo();
    }
    public class CustomerInfo
    {
      [XmlElement("Name")]
      public Name Name { get; set; }
    }
    public class Name
    {
      [XmlElement("Title", Namespace = "com/user/ds/sch/pii/v1")]
      public string Title { get; set; }
    }
