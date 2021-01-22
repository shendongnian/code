    using System;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            root.InnerXml = "<child>Hi!</child>";
            doc.Save(Console.Out);
        }
    }
