    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XNamespace gml = "http://www.opengis.net/gml/3.2";
                XNamespace lifr = "http://www.opengis.net/infragml/road/1.0";
                XDocument xmlDoc = XDocument.Load(FILENAME);
                List<XElement> pavement = xmlDoc.Descendants(lifr + "LineString").ToList();
                foreach (XElement coords in pavement)
                {
                    string id = (string)coords.Attribute(gml + "id");
                    string pos = string.Join(",", coords.Elements(gml + "pos").Select(x => (string)x));
                    Console.WriteLine("id = '{0}', positions = '{1}'", id, pos);
                }
                //with filtered results
                var ls1 = pavement.Where(x => (string)x.Attribute(gml + "id") == "ls1").FirstOrDefault();
                string positions = string.Join(",", ls1.Elements(gml + "pos").Select(x => (string)x));
                Console.ReadKey();
            }
        }
    }
