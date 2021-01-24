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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main()
            {
                new Log(FILENAME);
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
        }
    }
