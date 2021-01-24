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
                var results = doc.Descendants("person").Select(x => new {
                    name = x.Element("name"),
                    age = x.Element("age"),
                    age_name = x.Element("age").Element("name") == null ? string.Empty : (string)x.Element("age").Element("name")
                }).ToList();
            }
        }
    }
