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
                XNamespace yNs = doc.Root.GetNamespaceOfPrefix("y");
                Datas data = doc.Descendants(yNs + "datas").Select(x => new Datas() {
                    instances = x.Descendants(yNs + "instance").Select(y => new Instance() {
                        instance = (string)y.Attribute("yid"),
                        language = (string)y.Element("language").Attribute("yid"),
                        threshold = (decimal)y.Element("threshold"),
                        typePeriod = (string)y.Element("typePeriod"),
                        interval = (string)y.Element("interval"),
                        valuePeriod = (string)y.Element("valuePeriod"),
                        fund = y.Elements("fund").Select(z => new Fund() {
                            fields  = z.Elements().GroupBy(a => a.Name.LocalName, b => b.Elements()
                                .GroupBy(c => c.Name.LocalName, d => (string)d)
                                .ToDictionary(c => c.Key, d => d.FirstOrDefault()))
                                .ToDictionary(a => a.Key, b => b.FirstOrDefault())
                        }).FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
        public class Datas
        {
            public List<Instance> instances { get; set; }
        }
        public class Instance
        {
            public string instance { get; set; }
            public string language { get; set; }
            public decimal threshold { get; set; }
            public string typePeriod { get; set; }
            public string interval { get; set; }
            public string valuePeriod { get; set; }
            public Fund fund { get; set; }
         }
        public class Fund
        {
            public Dictionary<string, Dictionary<string,string>> fields { get; set; }
        }
    }
