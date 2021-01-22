    [XmlRoot(ElementName="ServiceResponse")]
    public class WS_ServiceResponse
    {
        public WS_ServiceResponseResult result { get; set; }
        
        [XmlElement(Type=typeof(WS_User), ElementName="WS_User")]
        [XmlElement(Type=typeof(string), ElementName="Text")]
        public object data { get; set; }
    }
 
