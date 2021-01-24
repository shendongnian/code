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
            const string FILENAME = @"c:\temp\gps.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                var results = doc.Descendants(ns + "trkpt").Select(x => new
                {
                    lat = x.Attribute("lat"),
                    lon = x.Attribute("lon"),
                    ele = (decimal)x.Element(ns + "ele"),
                    time = (DateTime)x.Element(ns + "time")
                }).ToList();
            }
        }
    }
