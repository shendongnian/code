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
                string ident = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Connected></Connected>";
                XDocument doc = XDocument.Load(FILENAME);
                var groups = doc.Descendants("Emp").GroupBy(x => (string)x.Element("A.EMPLID")).ToList();
                foreach (var group in groups)
                {
                    XDocument doc1 = XDocument.Parse(ident);
                    XElement root = doc1.Root;
                    root.Add(group);
                    doc1.Save(@"c:\temp\test" + group.Key + ".xml");
                }
            }
        }
    }
