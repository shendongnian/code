    [XmlRoot("ORDER")]
    public class Order
    {
        [XmlElement("PO_NO")] // note this one is implicit and not strictly needed
        public string PO_NO { get; set; }
        [XmlArray("ORDER_DETAILS")]
        [XmlArrayItem("ORDER_DETAIL")]
        public List<OrderDetails> OrderDetails {get;} = new List<OrderDetails>();
    }
