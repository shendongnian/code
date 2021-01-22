    using System;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace MyTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
    
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml("<Root><Child>Test</Child></Root>");
    
                var xDocument = xmlDocument.ToXDocument();
                var newXmlDocument = xDocument.ToXmlDocument();
                Console.ReadLine();
            }
        }
    
        public static class DocumentExtensions
        {
            public static XmlDocument ToXmlDocument(this XDocument xDocument)
            {
                var xmlDocument = new XmlDocument();
                using(var xmlReader = xDocument.CreateReader())
                {
                    xmlDocument.Load(xmlReader);
                }
                return xmlDocument;
            }
    
            public static XDocument ToXDocument(this XmlDocument xmlDocument)
            {
                using (var nodeReader = new XmlNodeReader(xmlDocument))
                {
                    nodeReader.MoveToContent();
                    return XDocument.Load(nodeReader);
                }
            }
        }
    }
