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
                XNamespace ns = doc.Root.GetNamespaceOfPrefix("tns");
                var results = doc.Descendants(ns + "responses")
                    .Where(x => x.Elements(ns + "Include").Any())
                    .Select(x => new {
                        include = (string)x.Element(ns + "Include"),
                        name = (string)x.Element(ns + "Name")
                    }).ToList();
            }
        }
    }
