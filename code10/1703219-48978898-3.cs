    [XmlRoot("FIBEX", Namespace = fxNameSpace)]
    public partial class Fibextoobject
    {
        [XmlElement("PROJECT", Namespace = fxNameSpace)]
        public Project project { get; set; }
        [XmlElement("ELEMENTS", Namespace = fxNameSpace)]
        public Elements elements { get; set; }
        public class Project
        {
            [XmlAttribute("OID", Namespace = hoNameSpace)]
            public string OID { get; set; }
            [XmlAttribute("ID")]
            public string ID { get; set; }
            [XmlElement("SHORT-NAME", Namespace = hoNameSpace)]
            public string shortname { get; set; }
            [XmlElement("LONG-NAME", Namespace = hoNameSpace)]
            public string longname { get; set; }
        }
        public class Elements
        {
            [XmlArray("CLUSTERS", Namespace = fxNameSpace)]
            [XmlArrayItem("CLUSTER", Namespace = fxNameSpace)]
            public List<Cluster> cluster { get; set; }
        }
        [XmlType("CLUSTER-TYPE", Namespace = ethernetNameSpace)]
        public class ClusterType : Cluster
        {
        }
        // The XmlTypeAttribute.Namespace below must be initialized to something if it is also initialized on the derived type.
        // However, the actual value does not need to be the same as the child's namespace, so modify to be something more appropriate
        // based on additional XML samples.
        [XmlType("CLUSTER", Namespace = "")] 
        [XmlInclude(typeof(ClusterType))]
        // Add XmlInclude for all additional subtypes here.
        public class Cluster
        {
            [XmlAttribute("ID")]
            public string ID { get; set; }
            [XmlElement("SHORT-NAME", Namespace = hoNameSpace)]
            public string shortname { get; set; }
            [XmlElement("SPEED", Namespace = fxNameSpace)]
            public string speed { get; set; }
        }
    }
    public partial class Fibextoobject
    {
        public const string fxNameSpace = "http://www.asam.net/xml/fbx";
        public const string hoNameSpace = "http://www.asam.net/xml";
        public const string ethernetNameSpace = "http://www.asam.net/xml/fbx/ethernet";
        public const string itNameSpace = "http://www.asam.net/xml/fbx/it";
        public const string serviceNameSpace = "http://www.asam.net/xml/fbx/services";
    }
