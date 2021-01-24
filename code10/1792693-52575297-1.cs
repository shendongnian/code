    using System;
    using System.Collections.Generic;
    using System.Collections;
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
                XElement abc = doc.Root;
                Dictionary<string, Dictionary<string,string>> dict = abc.Elements()
                    .GroupBy(x => x.Name.LocalName, y => y.Attributes()
                        .GroupBy(a => a.Name.LocalName, b => (string)b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
