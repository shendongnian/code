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
                Dictionary<string, Dictionary<string, string>> dict = doc.Descendants("VendorEntry")
                    .GroupBy(x => (string)x.Attribute("Name"), y => y.Descendants("Attribute")
                        .GroupBy(a => (string)a.Attribute("Name"), b => (string)b.Attribute("Value"))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
