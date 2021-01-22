    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var ns = new XmlNamespaceManager(new NameTable());
            ns.AddNamespace("ns", "http://www.epo.org/exchange");
            var elem = XDocument.Load("test.xml")
                .XPathSelectElement("//ns:document-id[ns:doc-number='1000']", ns);
            if (elem != null)
            {
                Console.WriteLine(elem.ToString());
            }
        }
    }
