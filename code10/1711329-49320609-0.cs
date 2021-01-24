    [XmlRoot(ElementName = "Prices")]
    public class Prices
    {
        [XmlAttribute(AttributeName = "price")]
        public string Price { get; set; }
    }
    [XmlRoot(ElementName = "Barcodes")]
    public class Barcodes
    {
        [XmlElement(ElementName = "barcode")]
        public List<string> Barcode { get; set; }
    }
    [XmlRoot(ElementName = "Product")]
    public class Product
    {
        [XmlElement(ElementName = "Prices")]
        public Prices Prices { get; set; }
        [XmlElement(ElementName = "Barcodes")]
        public Barcodes Barcodes { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
    }
    [XmlRoot(ElementName = "Products")]
    public class Products
    {
        [XmlElement(ElementName = "Product")]
        public List<Product> Product { get; set; }
    }
    [XmlRoot(ElementName = "Import")]
    public class Import
    {
        [XmlElement(ElementName = "Products")]
        public Products Products { get; set; }
    }
