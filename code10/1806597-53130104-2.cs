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
                List<Addresses> addresses = doc.Descendants("Addresses").Select(x => new Addresses() {
                    ListName = (string)x.Element("ListName"),
                    dict = x.Elements("Address")
                       .GroupBy(y => (string)y.Attribute("contextRef"), z => (string)z)
                       .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).ToList();
            }
        }
        public class Addresses
        {
            public string ListName { get; set; }
            public Dictionary<string, string> dict { get; set; }
        }
     
    }
