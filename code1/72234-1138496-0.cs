    static class XmlExtensions {
        // serialize an object to an XML string
        public static string ToXml(this object obj) {
            // remove the default namespaces
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            // serialize to string
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            StringWriter sw = new StringWriter();
            xs.Serialize(sw, obj, ns);
            return sw.GetStringBuilder().ToString();
        }
    }
    [XmlType("Element")]
    public class Element {
        [XmlAttribute("name")]
        public string name;
    }
    class Program {
        static void Main(string[] args) {
            Element el = new Element();
            el.name = "test";
            Console.WriteLine(el.ToXml());
        }
    }
