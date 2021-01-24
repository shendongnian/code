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
                XElement results = doc.Descendants().Where(x => x.Name.LocalName == "Results").FirstOrDefault();
                XNamespace nsC = results.GetNamespaceOfPrefix("c");
                Dictionary<string, List<string>> dict = results.Descendants(nsC + "KeyValueOfstringstring")
                   .GroupBy(x => (string)x.Element(nsC + "Key"), y => (string)y.Element(nsC + "Value"))
                   .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
