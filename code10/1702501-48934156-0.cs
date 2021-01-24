    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication25
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement entity = doc.Descendants().Where(x => x.Name.LocalName == "entity").FirstOrDefault();
                XNamespace ns = entity.GetDefaultNamespace();
                var results = entity.Elements().Select(x => new {
                    uzd = x.Name.LocalName,
                    dict = x.Descendants(ns + "row").Elements().GroupBy(y => y.Name.LocalName, z => (string)z)
                       .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).ToList();
            }
        }
    }
