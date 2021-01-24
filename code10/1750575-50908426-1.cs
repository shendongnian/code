    using System;
    using System.Linq;
    using System.Xml.Linq;
       
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            XNamespace ns = "http://tempuri.org/";
            var query = doc
                .Descendants(ns + "grantitem")
                .Elements(ns + "attribute")
                .Select(x => new { 
                    Key = (string) x.Attribute("key") ?? "",
                    Value = (string) x.Attribute("value") ?? ""
                });
            
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
