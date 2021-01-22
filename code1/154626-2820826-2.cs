     using System.Xml.Serialization;
        using System.Xml.Schema;
        [XmlRootAttribute(Namespace = "", IsNullable = false)]
        public class Basket
        {
            [XmlArrayAttribute("Fruits", Form = XmlSchemaForm.Unqualified)]
            [XmlArrayItemAttribute("Fruit", typeof(string), Form = XmlSchemaForm.Unqualified)]
            public List<string> _items;
        }
