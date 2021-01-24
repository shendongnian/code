    [XmlRoot(ElementName = "orders")]
    public class Orders
    {
        [XmlElement(ElementName = "order")]
        public List<OrderModel> OrdersList { get; set; }
    }
    
    [XmlRoot(ElementName = "order")]
    public class OrderModel
    {
        [XmlElement(ElementName = "customer_id")]
        public string CustomerId { get; set; }
    
        [XmlElement(ElementName = "order_code")]
        public string OrderCode { get; set; }
    
        [XmlArray(ElementName = "products")]
        [XmlArrayItem(ElementName = "product")]
        public List<Product> products { get; set; }
    }
