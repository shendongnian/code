    [XmlRoot("SAPInformationInterchangeXML")]
    public class EWayBillResponseXML
    {
        [XmlElement(ElementName = "SAPBusinessNetworkCustomerID")]
        public string SAPBusinessNetworkCustomerID { get; set; }
        [XmlElement(ElementName = "INVOIC")]
        public ResponseINVOIC Invoice { get; set; }
        public book ShouldSerializeInvoice()
        {
            return Invoice != null;
        }
    }
