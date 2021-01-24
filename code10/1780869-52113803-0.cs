    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            XNamespace ns = "http://www.abcd.com/dxl";
            var sentToValues = doc.Root
                .Elements(ns + "item")
                .Where(item => (string) item.Attribute("name") == "SentTo")
                .Select(item => (string) item.Element(ns + "text"))
                .ToList();
            foreach (var value in sentToValues)
            {
                Console.WriteLine(value);
            }
        }
    }
