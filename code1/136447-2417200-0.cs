    [XmlRoot("products")]
    public class ProductWrapper
    {
        private List<Product> products = new List<Product>();
        [XmlElement("product")]
        public List<Product> Products { get {return products; } }
    }
    public class Product
    {
    }
