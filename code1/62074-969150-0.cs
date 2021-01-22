    using System;
    using System.Xml;
    
    public class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            XmlElement email = doc.CreateElement("email");
            XmlNode cdata = doc.CreateCDataSection("test@test.com");
            
            doc.AppendChild(root);
            root.AppendChild(email);
            email.AppendChild(cdata);
            
            Console.WriteLine(doc.InnerXml);
        }
    }
