     using System.Xml.Serialization;
        using System.Xml.Schema;
        [XmlRootAttribute(Namespace = "", IsNullable = false)]
        public class Basket
        {
            [XmlArrayAttribute("Fruits", Form = XmlSchemaForm.Unqualified)]
            [XmlArrayItemAttribute("Fruit", typeof(Fruit), Form = XmlSchemaForm.Unqualified)]
            public List<Fruit> Items;
        }
        public class Fruit
        {
            [XmlTextAttribute()]
            public string Value;
        }
