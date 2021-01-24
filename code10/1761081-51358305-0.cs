    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication53
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string feed = File.ReadAllText(FILENAME);            
                XDocument doc = XDocument.Parse(feed);
                XElement properties = doc.Descendants().Where(x => x.Name.LocalName == "properties").FirstOrDefault();
                Dictionary<string, string> dict = properties.Elements()
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
