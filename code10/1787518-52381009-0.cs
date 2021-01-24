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
                Dictionary<int, int> dict = doc.Descendants("supply")
                    .GroupBy(x => (int)x.Element("id"), y => (int)y.Element("qty"))
                    .ToDictionary(x => x.Key, y => y.Sum());
            }
        }
    }
