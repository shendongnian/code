    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement routingOrder = doc.Descendants().Where(x => x.Name.LocalName == "Routing_Order").FirstOrDefault();
                Dictionary<string, string> orders = routingOrder.Elements()
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                string status = (string)doc.Descendants().Where(x => x.Name.LocalName == "Request_Status").FirstOrDefault();
                string requestType = (string)doc.Descendants().Where(x => x.Name.LocalName == "Request_Type").FirstOrDefault();
            }
        }
    }
