    [XmlRoot(ElementName = "SHOPITEM", Namespace = "")]
    public class ShopItem
    {
        [XmlElement("PRODUCTNAME")]
        public string ProductName { get; set; }
        [XmlElement("VARIANT")] // was [XmlArrayItem]
        public List<ShopItem> Variants { get; set; }
    }
    // ...
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", "");
    ShopItem item = new ShopItem()
    {
        ProductName = "test",
        Variants = new List<ShopItem>()
        {
            new ShopItem(){ ProductName = "hi 1" },
            new ShopItem(){ ProductName = "hi 2" }
        }
    };
    XmlSerializer ser = new XmlSerializer(typeof(ShopItem));
    ser.Serialize(Console.Out, item, ns);
