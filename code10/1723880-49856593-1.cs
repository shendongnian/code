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
                Dictionary<string, XElement> warehouses = doc.Descendants("Warehouse")
                    .GroupBy(x => (string)x.Element("GUID"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                XElement warehouse = warehouses["0d63057d-99e8-11e6-813b-0003ff000011"];
                Dictionary<string, XElement> terms = warehouse.Descendants("Term")
                    .GroupBy(x => (string)x.Attribute("TargetGUID"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                string value = terms["490ecabf-f011-11e3-b7d9-6c626dc1e098"].Value;
                warehouse.SetValue(value);
            }
        }
    }
      
