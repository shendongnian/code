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
                XElement scanElements = doc.Descendants("scanElements").FirstOrDefault();
                List<XElement> uniqueScanElements = scanElements.Elements("scanElement")
                    .Select(x => new { compoundName = x.Element("compoundName"), scanElement = x })
                    .GroupBy(x => x.compoundName)
                    .Select(x => x.FirstOrDefault())
                    .Select(x => x.scanElement)
                    .ToList();
                scanElements.ReplaceWith(new XElement("scanElements"), uniqueScanElements);
            }
        }
    }
