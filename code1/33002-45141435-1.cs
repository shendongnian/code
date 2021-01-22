    [XmlRoot(Namespace = "", ElementName = "Root")]
    public class Root
    {
        [XmlArray(ElementName = "ArrayNode", Namespace = "", IsNullable = false, Order = 1)]
        [XmlArrayItem("SubnodeType1")]
        public List<SubnodeType1> SubnodeType1 { get; set; }
        [XmlArray(ElementName = "ArrayNode", Namespace = "", IsNullable = false, Order = 2)]
        [XmlArrayItem("SubnodeType2")]
        public List<SubnodeType2> SubnodeType2 { get; set; }
    }
