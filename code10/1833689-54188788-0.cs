    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication94
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
     
                var results = doc.Descendants("Mjerenje").Select(x => new {
                    id = (string)x.Attribute("id"),
                    vrijednost = (int)x.Attribute("vrijednost"),
                    date = new DateTime((int)x.Attribute("godina"), (int)x.Attribute("mjesec"), (int)x.Attribute("dan"))
                }).ToList();
                var groups = results.GroupBy(x => x.date).ToList();
            }
        }
    }
