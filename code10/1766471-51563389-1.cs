    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication58
    {
        class Program
        {
            const string FILENAME = @"C:\TEMP\TEST.XML";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var query = doc.Descendants("customer").Select(x => new{
                    premise = (string)x.Descendants("service").FirstOrDefault().Attribute("premise"),
                    customFields = x.Descendants("customField").GroupBy(y => (string)y.Attribute("key"), z => (string)z.Attribute("value"))
                    .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).ToList();
                var results = query.Where(x => x.premise == "89645").FirstOrDefault();
            }
        }
    }
