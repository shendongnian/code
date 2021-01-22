    using System;
    using System.Xml;
    
    public class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<root xmlns='urn:xyz' rattr='a'>
               <child attr='1'>test</child></root>");
            XmlElement root = doc.DocumentElement;
            XmlNode clone = root.CloneNode(false);
            Console.WriteLine(clone.OuterXml);
        }
    }
