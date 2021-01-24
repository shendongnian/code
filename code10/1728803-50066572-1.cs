    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    namespace CharConversion
    {
        class Program
        {
            const string IN_FILENAME = @"c:\temp\test.xml";
            const string OUT_FILENAME = @"c:\temp\test1.xml";
            static void Main()
            {
                new Log(IN_FILENAME);
                Log.Write(OUT_FILENAME);
            }
        }
        public class Log
        {
            public static List<Log> lists { get; set; }
            public string id { get;set;}
            public int minValue { get; set;}
            public int maxValue { get; set;}
            public int minIndex { get;set;}
            public int maxIndex { get; set;}
            public int serverCount { get; set; }
            public Log() { }
            public Log(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                lists = doc.Descendants("logCurveInfo").Select(x => new Log() {
                    id = (string)x.Attribute("id"),
                    minValue = (int)x.Element("minValue"),
                    maxValue = (int)x.Element("maxValue"),
                    minIndex = (int)x.Element("minIndex"),
                    maxIndex = (int)x.Element("maxIndex"),
                    serverCount = (int)x.Element("serverCount")
                }).ToList();
                
            }
            public static void Write(string filename)
            {
                string xmlIdent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><log></log>";
                XDocument doc = XDocument.Parse(xmlIdent);
                XElement xLog = doc.Root;
                foreach (Log log in lists)
                {
                    xLog.Add(new XElement("logCurveInfo", new object[] {
                        new XAttribute("id", log.id),
                        new XElement("minValue", log.minValue),
                        new XElement("maxValue", log.maxValue),
                        new XElement("minIndex", log.minIndex),
                        new XElement("maxIndex", log.maxIndex),
                        new XElement("serverCount", log.serverCount)
                    }));
                }
                doc.Save(filename);
            }
        }
    }
