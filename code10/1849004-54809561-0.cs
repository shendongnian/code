    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            const string STATUS_XML_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string,Dictionary<string,string>> dict = doc.Descendants("properties")
                    .GroupBy(x => (string)x.Attribute("value"), y => y.Elements("property")
                        .GroupBy(a => (string)a.Attribute("name"), b => (string)b.Attribute("value"))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
