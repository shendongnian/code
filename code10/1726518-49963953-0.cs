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
                XElement catalog = doc.Root;
                Dictionary<string, List<XElement>> dict = catalog.Elements("book")
                    .OrderBy(x => (string)x.Attribute("id"))
                    .ThenBy(x => (DateTime)x.Element("publish_date"))
                    .GroupBy(x => (string)x.Attribute("id"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
