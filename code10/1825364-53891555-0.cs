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
                XElement plist = doc.Descendants("PList").FirstOrDefault();
                List<XElement> pName = plist.Elements("PName").ToList();
                var results = pName.Select(x => new {
                    bedType = (string)x.Descendants("Room").FirstOrDefault().Attribute("bedType"),
                    name = (string)x.Descendants("PName").FirstOrDefault().Attribute("title"),
                    id = (string)x.Descendants("PName").FirstOrDefault().Attribute("PId"),
                }).ToList();
            }
        }
    }
