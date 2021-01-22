    using System;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Login");
            XmlElement id = doc.CreateElement("id");
            id.SetAttribute("userName", "Tushar");
            id.SetAttribute("passWord", "Tushar");
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = "Tushar";
            XmlElement age = doc.CreateElement("Age");
            age.InnerText = "24";
            
            id.AppendChild(name);
            id.AppendChild(age);
            root.AppendChild(id);
            doc.AppendChild(root);
            
            doc.Save("test.xml");
        }
    }
