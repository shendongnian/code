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
                Dictionary<string, Dictionary<string, XElement>> dict = doc.Descendants("Warehouse")
                    .GroupBy(x => (string)x.Element("GUID"), y => y.Descendants("Term")
                        .GroupBy(a => (string)a.Attribute("TargetGUID"), b => b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, XElement> subDict = dict["0d63057d-99e8-11e6-813b-0003ff000011"];
                XElement term = subDict["490ecabf-f011-11e3-b7d9-6c626dc1e098"];
                term.SetValue(123);
            }
        }
    }
      
