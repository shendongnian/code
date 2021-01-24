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
                Dictionary<string, Dictionary<string, XElement>> dict = doc.Descendants("VendorEntry")
                    .GroupBy(x => (string)x.Attribute("Name"), y => y.Descendants("Attribute")
                        .GroupBy(a => (string)a.Attribute("Name"), b => b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                Dictionary<string, XElement> entry2 = dict["Entry2"];
                entry2["B"].SetAttributeValue("Value", "xyz");
                doc.Save(FILENAME);
            }
        }
    }
