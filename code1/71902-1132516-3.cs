    using System;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement element = doc.CreateElement("tag");
            element.InnerText = "Brackets & stuff <>";
            Console.WriteLine(element.OuterXml);
        }
    }
