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
                List<PLC> plcs = doc.Root.Elements().Select(x => new PLC() {
                    ipAddress = (string)x.Element("ip"),
                    article = (int)x.Descendants("article").FirstOrDefault(),
                    prod = (int)x.Descendants().Where(y => y.Name.LocalName.StartsWith("prod")).FirstOrDefault(),
                    registerId = (int)x.Descendants("registerId").FirstOrDefault(),
                    registerDescription = (int)x.Descendants("registerDescription").FirstOrDefault(),
                    registerTarget = (int)x.Descendants("registerTarget").FirstOrDefault()
                }).ToList();
            }
        }
        public class PLC
        {
            public string ipAddress { get; set; }
            public int article { get; set; }
            public int prod { get; set; }
            public int registerId { get; set; }
            public int registerDescription { get; set; }
            public int registerTarget { get; set; }
        }
     
     
    }
