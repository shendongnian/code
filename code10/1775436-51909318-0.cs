    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq ;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            public static void Main()
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string,string> hrefs = doc.Descendants().Select(x => x.Attributes().Where(y => y.Name.LocalName == "href")).SelectMany(x => x)
                    .GroupBy(x => (string)x, y => y.Name.NamespaceName)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, List<XElement>> dict = doc.Descendants().Where(x => hrefs.ContainsKey((string)x))
                    .GroupBy(x => hrefs[(string)x], y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());     
     
            }
        }
     
    }
