    [XmlRoot(Namespace="http://example.com/compxref/abctype")]
    public class MassMatchQCResponseMsg{
        [XmlElement(Namespace="")]
        public MassMatchDet MassMatchDet {get;set;}
    }
    public class MassMatchDet
    {
        public string InputProductNumber {get;set;}
    }
