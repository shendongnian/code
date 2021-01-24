    [XmlRoot("Node", Namespace="http://somenamepsace")]
    public class MyType {
        [XmlElement("childNode")]
        public string Value { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("myNamespace", "http://somenamepsace");
            XmlSerializer xser = new XmlSerializer(typeof(MyType));
            xser.Serialize(Console.Out, new MyType(), ns);
        }
    }
