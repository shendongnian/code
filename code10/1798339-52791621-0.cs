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
                XElement period = doc.Descendants("Period").FirstOrDefault();
                MPD mpd = new MPD();
                mpd.duration = (string)period.Attribute("duration");
                mpd.start = (string)period.Attribute("start");
                mpd.adaptions = period.Elements("AdaptationSet").Select(x => new Adaption() {
                    contentType = (string)x.Element("ContentComponent").Attribute("contentType"),
                    id = (int)x.Element("ContentComponent").Attribute("id"),
                    representations = x.Elements("Representation").Select(y => new Representation() {
                        bandwidth = (int)y.Attribute("bandwidth"),
                        codecs = (string)y.Attribute("codecs"),
                        height = (int?)y.Attribute("height"),
                        id = (int)y.Attribute("id"),
                        mimeType = (string)y.Attribute("mimeType"),
                        width = (int?)y.Attribute("width"),
                        baseURL = (string)y.Descendants("BaseURL").FirstOrDefault()
                    }).ToList()
                }).ToList();
            }
        }
        public class MPD
        {
            public string duration { get; set; }
            public string start { get; set; }
            public List<Adaption> adaptions { get; set; }
        }
        public class Adaption
        {
            public string contentType { get; set; }
            public int id { get; set; }
            public List<Representation> representations { get; set; }
        }
        public class Representation
        {
            public int bandwidth { get; set; }
            public string codecs { get; set; }
            public int? height { get; set; }
            public int id { get; set; }
            public string mimeType { get; set; }
            public int? width { get; set; }
            public string baseURL { get; set; }
        }
    }
