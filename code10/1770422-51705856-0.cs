    [XmlRoot(ElementName = "orders")]
    public class Orders
    {
        [XmlElement(ElementName = "order")]
        public List<OrderModel> OrdersList { get; set; }
    }
        
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
    
    public class Product
    {
        [XmlElement(ElementName = "product_item_code")]
        public string product_item_code { get; set; }
    
        [XmlElement(ElementName = "product_item_amount")]
        public string product_item_amount { get; set; }
    }
  
        
        
