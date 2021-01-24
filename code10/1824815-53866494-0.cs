    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication93
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, string> dict = doc.Descendants("Node")
                    .GroupBy(x => (string)x.Attribute("name"), y => (string)y.Element("Element").Attribute("attribute"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //or if you have multiple items with same key
                Dictionary<string, List<string>> dict2 = doc.Descendants("Node")
                    .GroupBy(x => (string)x.Attribute("name"), y => (string)y.Element("Element").Attribute("attribute"))
                    .ToDictionary(x => x.Key, y => y.ToList());
     
            }
        }
     
     
    }
