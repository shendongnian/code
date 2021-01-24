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
                Dictionary<int, string> dict = doc.Descendants("HEADER")
                    .GroupBy(x => (int)x.Element("No"), y => (string)y.Element("Description"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
