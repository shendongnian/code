    using System;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main()
        {
            string xml = "<element1><element2>some data</element2></element1>";
    
            XDocument doc = XDocument.Parse(xml);
            xml = doc.ToString();
            Console.WriteLine(xml);
        }
    }
