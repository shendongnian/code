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
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                List<Naptan> atcoCodes = doc.Descendants(ns + "StopPoint").Select(x => new Naptan()
                {
                    AtcoCode = (string)x.Element(ns + "AtcoCode"),
                    NaptanCode = (string)x.Element(ns + "NaptanCode"),
                    Latitude = (double)x.Descendants(ns + "Latitude").FirstOrDefault(),
                    Longitude = (double)x.Descendants(ns + "Longitude").FirstOrDefault(),
                    TimmingStatus = (string)x.Descendants(ns + "TimingStatus").FirstOrDefault(),
                    BusStopType = (string)x.Descendants(ns + "BusStopType").FirstOrDefault(),
                    CommonName = (string)x.Descendants(ns + "CommonName").FirstOrDefault(),
                    Landmark = (string)x.Descendants(ns + "Landmark").FirstOrDefault(),
                    Street = (string)x.Descendants(ns + "Street").FirstOrDefault(),
                    Indicator = (string)x.Descendants(ns + "Indicator").FirstOrDefault()
                }).ToList();
            }
        }
        class Naptan
        {
            public string AtcoCode { get; set; }
            public string NaptanCode { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string TimmingStatus { get; set; }
            public string BusStopType { get; set; }
            public string CommonName { get; set; }
            public string Landmark { get; set; }
            public string Street { get; set; }
            public string Indicator { get; set; }
        }
    }
