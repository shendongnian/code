    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication78
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string xml = 
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<note>" +
                        "<to>Tove</to>" +
                        "<from>Jani</from>" +
                        "<heading>Reminder</heading>" +
                        "<body>Don't forget me this weekend!</body>" +
                    "</note>";
                XDocument doc = XDocument.Parse(xml);
                XElement from = doc.Descendants("from").FirstOrDefault();
                XElement heading = doc.Descendants("heading").FirstOrDefault();
                XElement body = doc.Descendants("body").FirstOrDefault();
                from.Add(heading);
                XElement example = new XElement("example", new object[] {from,body});
                heading.Remove();
                body.Remove();
                from.ReplaceWith(example);
            }
        }
    }
