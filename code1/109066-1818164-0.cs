    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            XNamespace gml = "http://www.opengis.net/gml";
            
            var query = doc.Descendants(gml + "coord")
                .Select(e => new { X = (decimal) e.Element(gml + "X"),
                                   Y = (decimal) e.Element(gml + "Y") });
            
            foreach (var c in query)
            {
                Console.WriteLine(c);
            }
        }
    }
