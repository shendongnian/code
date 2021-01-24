    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication25
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
           static void Main(string[] args)
            {
               XDocument doc = XDocument.Load(FILENAME);
               XmlDoc xmlDoc = new XmlDoc(doc.Root);
     
            }
        }
        public class XmlDoc
        {
            public Dictionary<string,string> properties { get; set; }
            public Dictionary<string, Dictionary<string,string>> items { get; set; }
            public XmlDoc(XElement root)
            {
                properties = root.Descendants("property")
                    .GroupBy(x => (string)x.Attribute("id"), y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                items = root.Descendants("item")
                    .GroupBy(x => (string)x.Attribute("id"), y =>
                        y.Elements().GroupBy(a => a.Name.LocalName, b => (string)b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                        .ToDictionary(x => x.Key, y => y.First());
                        
            }
        }
    }
