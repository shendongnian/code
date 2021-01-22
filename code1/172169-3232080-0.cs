    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var nsmgr = new XmlNamespaceManager(new NameTable());
            nsmgr.AddNamespace("bmml", "http://www.X.com/2002/bmml");
            var urls = doc.XPathSelectElements("//bmml:url", nsmgr);
            foreach (var url in urls)
            {
                Console.WriteLine(url.Value);
            }
        }
    }
