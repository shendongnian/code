    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load(@"c:\nota.xml");
            var cuf = doc.XPathSelectElement("//cUF");
            if (cuf != null)
            {
                Console.WriteLine(cuf.Value);
            }
        }
    }
