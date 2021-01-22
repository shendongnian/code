    [XmlRoot(ElementName="ItemCollection")]
    public class ItemCollection : Collection<Item>
    {
       [XmlElement(ElementName="Name")]
       public string Name {get;set;}
    }
