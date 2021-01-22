    public class StorageObject {
      public string Name { get; set; }
      public string Birthday { get; set; }
      [XmlAnyElement("Info")]  // this prevents double-nodes in the XML
      public XElement OtherInfo { get; set; }
    }
