    [XmlRoot(ElementName = "eAction", Namespace = "http://www.action.org/standards/PC_Surety/action1/xml/")]
    public class eAction
    {
        [XmlAttribute(Namespace = XmlSchema.InstanceNamespace)]
        public string schemaLocation = "http://www.action.org/standards/PC_Surety/action1/xml/standardsFile.xsd";
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public eAction()
        {
            xmlns.Add("cation", "http://www.caction.org/standards/pc_go/xml/");
            xmlns.Add("acme", "http://www.ACME.org/standards/ACME1/xml/");
            xmlns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        }
        public string Name = string.Empty;
        public string Street1 = string.Empty;
        public string Street2 = string.Empty;
        public string City = string.Empty;
        public string State = string.Empty;
        public string PostalCode = string.Empty;
        public OtherInformation OtherInformation = new OtherInformation();
    }
    public class OtherInformation
    {
        public string DateOfBirth = string.Empty;
        public string SSN = string.Empty;
    }
