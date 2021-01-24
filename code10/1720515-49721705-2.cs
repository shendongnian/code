    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                IFormatProvider provider = CultureInfo.InvariantCulture;
                List<Compo> compos = doc.Descendants("COMPO").Select(x => new Compo() {
                    alim_code = (int?)x.Element("alim_code"),
                    const_code = (int?)x.Element("const_code"),
                    teneur =  (string)x.Element("teneur") == "" ? null : (decimal?)Convert.ToDecimal((string) x.Element("teneur"),provider),
                    min = (string)x.Element("min") == "" ? null : (decimal?)Convert.ToDecimal((string) x.Element("teneur"),provider),
                    max = (string)x.Element("max") == "" ? null : (decimal?)Convert.ToDecimal((string) x.Element("teneur"),provider),
                    code_confiance = (string)x.Element("code_confiance"),
                    source_code = (string)x.Element("source_code") == "" ? null : (int?)int.Parse(((string)x.Element("source_code")).Trim())
                }).ToList();
            }
        }
        public class Compo
        {
            public int? alim_code {get; set;}
            public int? const_code {get; set;}
            public decimal? teneur {get; set;}
            public decimal? min {get; set;}
            public decimal? max {get; set;}
            public string code_confiance {get; set;}
            public int? source_code { get; set; }
        }
    }
