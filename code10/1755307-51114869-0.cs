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
                List<XElement> games = doc.Descendants("game").ToList();
                string picture = games.Where(x => (string)x.Element("name") == "mylifeisdone").Select(x => (string)x.Element("picture")).FirstOrDefault();
            }
        }
    }
