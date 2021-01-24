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
                int index = 1;
                foreach (XElement emp in doc.Descendants("Emp"))
                {
                    XDocument doc1 = XDocument.Parse(ident);
                    XElement root = doc1.Root;
                    root.Add(emp);
                    doc1.Save(@"c:\temp\test" + index.ToString() + ".xml");
                    index++;
                }
            }
        }
    }
