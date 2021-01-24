    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication91
    {
        class Program
        {
            static void Main(string[] args)
            {
                string ws = "http://www.w3.org/2005/08/addressing";
                string xml = string.Format( 
                             "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                             "<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\">" +
                             "<s:Header>" +
                             "<wsa:Address xmlns:wsa=\"{0}\">ws://xxx/V1</wsa:Address>" +
                             "</s:Header>" +
                             "<s:Body>" +
                             "</s:Body>" +
                             "</s:Envelope>",
                             ws);
                XDocument doc = XDocument.Parse(xml);
                XElement header = doc.Descendants().Where(x => x.Name.LocalName == "Header").FirstOrDefault();
                XElement body = doc.Descendants().Where(x => x.Name.LocalName == "Body").FirstOrDefault();
            }
        }
    }
