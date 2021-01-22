        [Serializable()]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false, ElementName = "rootnode")]
        public partial class RootNode
        {
            [System.Xml.Serialization.XmlElementAttribute("collection1")]
            public List<OuterCollection> OuterCollections { get; set; }
        }
        [Serializable()]
        public partial class OuterCollection
        {
            [XmlAttribute("attribute1")]
            public string attribute1 { get; set; }
            [XmlArray(ElementName = "innercollection1")]
            [XmlArrayItem("text", Type = typeof(InnerCollection1))]
            public List<InnerCollection1> innerCollection1Stuff { get; set; }
            [XmlArray("innercollection2")]
            [XmlArrayItem("text", typeof(InnerCollection2))]
            public List<InnerCollection2> innerConnection2Stuff { get; set; }
        }
        [Serializable()]
        public partial class InnerCollection2
        {
            [XmlText()]
            public string text { get; set; }
        }
        public partial class InnerCollection1
        {
            [XmlText()]
            public int number { get; set; }
        }
}
