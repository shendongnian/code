    [Serializable, XmlRoot("add")]
    public class KeyValue
    {
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        public static KeyValue Deserialize(string xml)
        {
            KeyValue keyValue = null;
            var serializer = new XmlSerializer(typeof(KeyValue));
            using (var reader = new StringReader(xml))
            {
                keyValue = (KeyValue)(serializer.Deserialize(reader));
            }
            return keyValue;
        }
    }
    [Serializable, XmlRoot("product")]
    public class Product
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "price")]
        public decimal Price { get; set; }
        [XmlElement("add")]
        public List<KeyValue> KeyValueList { get; set; }
        public static Product Deserialize(string xml)
        {
            Product product = null;
            var serializer = new XmlSerializer(typeof(Product));
            using (var reader = new StringReader(xml))
            {
                product = (Product)(serializer.Deserialize(reader));
            }
            return product;
        }
    }
