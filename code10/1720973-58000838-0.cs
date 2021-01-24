    public class Document
    {
        [XmlElement(ElementName = "seller_id")]
        public string SellerId { get; set; }
        [XmlArray(ElementName = "order_details")]
        [XmlArrayItem(Type = typeof(SgtinCode), ElementName = "sgtin")]
        [XmlArrayItem(Type = typeof(SsccCode), ElementName = "sscc")]
        public Code[] Codes { get; set; }
    }
    public abstract class Code
    {
        [XmlText]
        public string Value { get; set; }
    }
    public class SgtinCode : Code
    { }
    public class SsccCode : Code
    { }
