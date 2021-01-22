    using System;
    using System.Xml.Linq;
    
    class Test
    {   
        static void Main(string[] args)
        {
            string xml = "<?xml version=\"1.1\" ?><root><sub /></root>";
            XDocument doc = XDocument.Parse(xml);
            Console.WriteLine(doc);
        }
    }
