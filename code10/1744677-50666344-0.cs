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
                new Item(FILENAME);
            }
        }
        public class Item
        {
            public static List<Item> items { get; set; }
            public string availability { get; set; }
            public string id { get; set; }
            public Item() { }
            public Item(string filename)
            {
                string xml = File.ReadAllText(filename);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                Item.items = doc.Descendants(ns + "item").Select(x => new Item() {
                    availability = (string)x.Element(ns + "availability"),
                    id = (string)x.Element(ns + "id")
                }).ToList();
            }
        }
    }
