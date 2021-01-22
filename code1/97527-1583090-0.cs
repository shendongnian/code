    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("http://seattle.craigslist.org/sof/index.rss");
            XNamespace rss = "http://purl.org/rss/1.0/";
    
            foreach (var item in doc.Descendants(rss + "item"))
            {
                Console.WriteLine(item.Element(rss + "link").Value);
            }
    
            Console.Read();
        }
    }
