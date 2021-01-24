     [XmlRoot(ElementName = "eAction", Namespace = "http://www.action.org/standards/PC_Surety/action1/xml/")]
    public class eAction
    {
       // your second ask:  "add schemaLocation"
       // add this line:
               [XmlAttribute(Namespace = XmlSchema.InstanceNamespace)]
        public string schemaLocation = "http://www.action.org/standards/PC_Surety/action1/xml/standardsFile.xsd";
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
