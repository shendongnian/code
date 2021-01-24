    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication83
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, object> dict = doc.Root.Elements()
                    .GroupBy(x => x.Name.LocalName, y => new
                    {
                        drinks = y.Descendants("drink").Select(z => (string)z.Attribute("value")).ToList(),
                        foods = y.Descendants("food").Select(z => (string)z.Attribute("value")).ToList()
                    })
                    .ToDictionary(x => x.Key, y => (object)y.FirstOrDefault());
            }
        
        }
    }
