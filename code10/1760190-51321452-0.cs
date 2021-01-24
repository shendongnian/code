    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, int> players = doc.Descendants("item")
                    .GroupBy(x => (string)x.Descendants("string").FirstOrDefault(), y => (int)y.Descendants("Points").FirstOrDefault())
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
     
     
    }
