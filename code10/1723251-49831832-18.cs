    [XmlRoot(ElementName = "myroot")]
    public class MyRoot : RootElementBase<ItemType>
    {
        [XmlElement("item")]
        public override List<ItemType> SubElements { get; set; }
    }
