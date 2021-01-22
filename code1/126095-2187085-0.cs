    public class CustomerModel
    {
      public CustomerModel(XElement xml)
      {
        this.Name = xml.XPathSelectElement("site[@id = 'customerName']").Value;
      }
      public string Name { get; set; }
    }
