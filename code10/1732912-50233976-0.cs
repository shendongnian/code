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
                Dictionary<string, string> items = doc.Descendants("ItemData")
                    .GroupBy(x => (string)x.Attribute("ItemID"), y => y.Attribute("IsNull") == null ? "Null" : (string)y.Attribute("ItemID"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                //if above fails tgry following
                Dictionary<string, List<string>> items2 = doc.Descendants("ItemData")
                    .GroupBy(x => (string)x.Attribute("ItemID"), y => y.Attribute("IsNull") == null ? "Null" : (string)y.Attribute("ItemID"))
                    .ToDictionary(x => x.Key, y => y.ToList());
                //or use two level dictionary
                Dictionary<string, Dictionary<string,string>> items3 = doc.Descendants("FormData")
                    .GroupBy(x => (string)x.Attribute("FormID"), y => y.Descendants("ItemData")
                        .GroupBy(a => (string)a.Attribute("ItemID"), b => b.Attribute("IsNull") == null ? "Null" : (string)y.Attribute("ItemID"))
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
