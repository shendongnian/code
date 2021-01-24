    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants("FIELD").Select(x => new {
                    fieldName = (string)x.Attribute("fieldName"),
                    childID = (string)x.Attribute("childID"),
                    value = (string)x
                }).ToList();
            }
        }
    }
