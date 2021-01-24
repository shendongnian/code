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
                string xAttribute = "coffee";
                Dictionary<int, Dictionary<string, KeyValuePair<string, string>>> dict = doc.Descendants("Commodity").Where(el => xAttribute == (string)el.Attribute("name"))
                    .Select(x => x.Descendants("Year")
                    .GroupBy(s => (int)s.Attribute("value"), t => t.Elements()
                        .GroupBy(u => u.Name.LocalName, v => new KeyValuePair<string, string>((string)v.Attribute("expiration"), (string)v.Attribute("associatedcontract")))
                            .ToDictionary(u => u.Key, v => v.FirstOrDefault()))
                            .ToDictionary(s => s.Key, t => t.FirstOrDefault())).FirstOrDefault();
            }
        }
    }
