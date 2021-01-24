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
                Dictionary<string, Dictionary<DateTime, int>> dict = doc.Descendants("Work")
                    .GroupBy(x => (string)x.Element("Name"), y => y.Descendants("Day")
                        .GroupBy(a => ((DateTime)a.Element("Date")).Add((new TimeSpan(((DateTime)a.Element("StartTime")).Hour,((DateTime)a.Element("StartTime")).Minute,0))), b => (int)b.Element("Attended"))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
             }
        }
     
    }
