    [XmlRoot(Namespace = "http://schemas.microsoft.com/netfx/2009/xaml/activities")]
    public class Activity
    {
        [XmlAttribute(Namespace = "http://schemas.microsoft.com/netfx/2009/xaml/activities")]
        public string Ignorable { get; set; }
        [XmlAttribute(Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
        public string Class { get; set; }
        [XmlElement("TextExpression.NamespacesForImplementation")]
        public NamespacesForImplementation NamespacesForImplementation { get; set; }
    }
    public class NamespacesForImplementation
    {
        [XmlElement(Namespace = "clr-namespace:System.Collections.ObjectModel;assembly=mscorlib")]
        public NamespaceCollection Collection { get; set; }
    }
    public class NamespaceCollection
    {
        [XmlAttribute(Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
        public string TypeArguments { get; set; }
        [XmlElement(ElementName = "String", Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
        public List<string> Content { get; set; }
    }
