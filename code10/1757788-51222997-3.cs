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
                List<Element> elements = doc.Descendants("Element").Select(x => new Element() {
                    type = (string)x.Attribute("Type"),
                    indice = (int)x.Attribute("Indice"),
                    name = x.FirstNode.ToString(),
                    haut = (decimal)x.Descendants ("Haut").FirstOrDefault(),
                    bas = (decimal)x.Descendants("Bas").FirstOrDefault(),
                    points = x.Elements("Point").Select(y => new Point() {
                        id = (string)y.Attribute("id"),
                        x = (decimal)y.Attribute("X"),
                        y = (decimal)y.Attribute("Y"),
                        value = (int)y
                    }).ToList()
                }).ToList();
            }
        }
        public class Element
        {
            public string type { get; set; }
            public int indice { get; set; }
            public string name { get; set; }
            public decimal haut { get; set; }
            public decimal bas { get; set; }
            public List<Point> points { get; set;}
        }
        public class Point
        {
            public string id { get; set; }
            public decimal x { get; set; }
            public decimal y { get; set; }
            public int value { get; set; }
        }
    }
