    [XmlRoot(ElementName = "fileHeader", Namespace = "http://www.3gpp.org")]
    public class FileHeader
    {
        [XmlAttribute(AttributeName = "fileFormatVersion")]
        public string FileFormatVersion { get; set; }
        [XmlAttribute(AttributeName = "vendorName")]
        public string VendorName { get; set; }
    }
    [XmlRoot(ElementName = "attributes", Namespace = "http://www.3gpp.org")]
    public class Attributes
    {
        [XmlElement(ElementName = "userLabel", Namespace = "http://www.3gpp.org")]
        public string UserLabel { get; set; }
        [XmlElement(ElementName = "manufacturerData", Namespace = "http://www.3gpp.org")]
        public string ManufacturerData { get; set; }
        [XmlElement(ElementName = "vendorUnitTypeNumber", Namespace = "http://www.3gpp.org")]
        public string VendorUnitTypeNumber { get; set; }
    }
    [XmlRoot(ElementName = "InventoryUnit", Namespace = "http://www.3gpp.org")]
    public class InnerInventoryUnit
    {
        [XmlElement(ElementName = "attributes", Namespace = "http://www.3gpp.org")]
        public Attributes Attributes { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
    [XmlRoot(ElementName = "InventoryUnit", Namespace = "http://www.3gpp.org")]
    public class InventoryUnit
    {
        [XmlElement(ElementName = "attributes", Namespace = "http://www.3gpp.org")]
        public Attributes Attributes { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "InventoryUnit", Namespace = "http://www.3gpp.org")]
        public List<InnerInventoryUnit> IU { get; set; }
    }
    [XmlRoot(ElementName = "TestElement", Namespace = "http://www.3gpp.org")]
    public class TestElement
    {
        [XmlElement(ElementName = "InventoryUnit", Namespace = "http://www.3gpp.org")]
        public List<InventoryUnit> InventoryUnit { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
    [XmlRoot(ElementName = "testDataFile", Namespace = "http://www.3gpp.org")]
    public class TestDataFile
    {
        [XmlElement(ElementName = "fileHeader", Namespace = "http://www.3gpp.org")]
        public FileHeader FileHeader { get; set; }
        [XmlElement(ElementName = "TestElement", Namespace = "http://www.3gpp.org")]
        public List<TestElement> TestElement { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "xn", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xn { get; set; }
        [XmlAttribute(AttributeName = "in", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string In { get; set; }
    }
