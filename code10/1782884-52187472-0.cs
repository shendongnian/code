    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication62
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("Kunde").Select(x => new
                {
                    email = (string)x.Element("Email"),
                    num = (string)x.Element("Kundennummer")
                }).ToList();
            }
        }
    }
