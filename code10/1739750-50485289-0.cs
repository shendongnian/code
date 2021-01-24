    [CollectionDataContract(Name = "Container", Namespace = "")]
    public class Container : System.Collections.Generic.List<Item>
    {
         [XmlAttribute]
         public string Name { get; set; }
    }
    [DataContract(Name = "Item", Namespace = "")]
    public class Item
    {
       // Properties
    }
