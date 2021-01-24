    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
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
                Dictionary<int, string> dict = doc.Descendants("Step")
                    .Where(x => (string)x.Element("ACTION") == "Point")
                    .GroupBy(x => (int)x.Attribute("ID"), y => (string)y.Element("CLASS_ID"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
     
    }
