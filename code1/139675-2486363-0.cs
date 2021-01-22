    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main(string[] args)
        {
            var kml = XDocument.Load("test.kml");
            var ns = new XmlNamespaceManager(new NameTable());
            ns.AddNamespace("kml", "http://www.opengis.net/kml/2.2");
            var names = kml.XPathSelectElements("//kml:Placemark/kml:name", ns);
            foreach (var name in names)
            {
                name.Value = "testing";
            }
            kml.Save("test.kml");
        }
    }
