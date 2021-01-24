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
                var dict = doc.Descendants("Question")
                    .GroupBy(x => (int)x.Attribute("number"), y => new {
                          type = (string)y.Attribute("type"),
                          bone = (string)y.Attribute("bone"),
                          answer = (string)y.Element("Answer").Attribute("label"),
                          choices = y.Descendants("Choice").GroupBy(a => (string)a.Attribute("label"), b => new KeyValuePair<string,string>((string)b.Attribute("region"),(string)b))
                              .ToDictionary(a => a.Key, b => b.FirstOrDefault())
                    }).ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
