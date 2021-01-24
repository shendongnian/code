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
                new Navlog(FILENAME); 
            }
        }
        public class Navlog
        {
            public static List<Navlog> logs { get; set; }
            public string ident { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public decimal? frequency { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string stage { get; set; }
            public string airway { get; set; }
            public string star { get; set; }
            public int distance { get; set; }
            public Navlog() { }
            public Navlog(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                Navlog.logs = doc.Descendants("fix").Select(x => new Navlog()
                {
                    ident = (string)x.Element("ident"),
                    name = (string)x.Element("name"),
                    type = (string)x.Element("type"),
                    frequency = (string)x.Element("frequency") == "" ? null : (decimal?)x.Element("frequency"),
                    latitude = (double)x.Element("pos_lat"),
                    longitude = (double)x.Element("pos_long"),
                    stage = (string)x.Element("stage"),
                    airway = (string)x.Element("via_airway"),
                    star = (string)x.Element("is_std_star"),
                    distance = (int)x.Element("distance"),
                }).ToList();
            }
        }
    }
