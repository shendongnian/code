    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApp2
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main()
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> PRODOTTO = doc.Descendants().Where(x => x.Name.LocalName == "PRODOTTO").Select(x => x.Elements()).SelectMany(x => x).ToList();
                Dictionary<string, string> products = PRODOTTO
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //use following if more than one item with same tag
                Dictionary<string, List<string>> products2 = PRODOTTO
                  .GroupBy(x => x.Name.LocalName, y => (string)y)
                  .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
