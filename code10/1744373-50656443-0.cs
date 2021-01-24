    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var max = doc.Root
                .Elements(ns + "url")
                .Max(url => (DateTime) url.Element(ns + "lastmod"));
            Console.WriteLine(max);
        }
    }
