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
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                XElement firstItem = doc.Descendants(ns + "item").FirstOrDefault();
                Dictionary<string, string> dictItems = firstItem.Descendants(ns + "item")
                    .GroupBy(x => (string)x.Element("key"), y => (string)y.Element("value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
    }
