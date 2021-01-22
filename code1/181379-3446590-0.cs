    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            string xml = "<element attr1='Hello' attr2='there' />";
            XElement element = XElement.Parse(xml);
            foreach (XAttribute attr in element.Attributes())
            {
                Console.WriteLine("{0}={1}", attr.Name, attr.Value);
            }
        }
    }
