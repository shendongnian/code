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
                List<Compo> compos = doc.Descendants("COMPO").Select(x => new Compo() {
                    alim_code = (int?)x.Element("alim_code"),
                    const_code = (int?)x.Element("const_code"),
                    teneur = (decimal?)x.Element("teneur"),
                    min = (decimal?)x.Element("min"),
                    max = (decimal?)x.Element("max"),
                    code_confiance = (string)x.Element("code_confiance"),
                    source_code = (int?)x.Element("source_code missing")
                }).ToList();
            }
        }
        public class Compo
        {
            public int? alim_code {get; set;}
            public int? const_code {get; set;}
            public decimal? teneur {get; set;}
            public decimal?min {get; set;}
            public decimal?max {get; set;}
            public string code_confiance {get; set;}
            public int? source_code { get; set; }
        }
    }
