    [XmlRoot("Node", Namespace="http://flibble")]
    public class MyType {
        [XmlElement("chileNode")]
        public string Value { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("myNamespace", "http://flibble");
            XmlSerializer xser = new XmlSerializer(typeof(MyType));
            xser.Serialize(Console.Out, new MyType(), ns);
        }
    }
