    [XmlRoot(Namespace="http://STPMonitor.myDomain.com")]
    public class CFMessage : IQueueMessage<CFQueueItem>
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns;
        [XmlAttribute("schemaLocation", Namespace=System.Xml.Schema.XmlSchema.InstanceNamespace)]
        public string schemaLocation = "http://STPMonitor.myDomain.com/schemas/CFMessage.xsd";
        [XmlAttribute("type")]
        public string Type { get; set; }
        
        [XmlAttribute("username")]
        public string UserName { get; set; }
        [XmlAttribute("somestring", Namespace = "http://someURI.com")]
        public string SomeString = "Hello World";
           
        
        public List<CFQueueItem> QueueItems { get; set; }
        public CFMessage()
        {
            xmlns = new XmlSerializerNamespaces();
            xmlns.Add("myDomain", "http://STPMonitor.myDomain.com");
            xmlns.Add("xyz", "http://someURI.com");
        }
    }
    <?xml version="1.0" encoding="utf-16"?>
    <myDomain:CFMessage xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xyz="http://someURI.com"
    xsi:schemaLocation="http://STPMonitor.myDomain.com/schemas/CFMessage.xsd"
    xyz:somestring="Hello World" type="JOIN" username="SJ-3-3008-1"
    xmlns:myDomain="http://STPMonitor.myDomain.com" />
