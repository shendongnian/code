    using System;
    using System.Globalization;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            
            string ns = "http://sample/namespace";
            XmlAttribute nsAttribute = doc.CreateAttribute("xmlns", "xx",
                "http://www.w3.org/2000/xmlns/");
            nsAttribute.Value = ns;
            root.Attributes.Append(nsAttribute);
            
            doc.AppendChild(root);
            XmlElement child = doc.CreateElement("child");
            root.AppendChild(child);
            XmlAttribute newAttribute = doc.CreateAttribute("xx","abc", ns);
            newAttribute.Value = "ddd";        
            child.Attributes.Append(newAttribute);
            
            doc.Save(Console.Out);
        }
    }
