    [System.SerializableAttribute()]
    public class Product
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Key]
        public int product_id { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("Country_Markets", typeof(Country_Markets), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Country_Markets { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("Distributors", typeof(Distributors), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Distributors items { get; set; }
    }
