    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    
    class Test
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            XmlElement element = doc.CreateElement("child");
            root.AppendChild(element);
            doc.AppendChild(root);
            
            MemoryStream ms = new MemoryStream();
            doc.Save(ms);
            byte[] bytes = ms.ToArray();
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
        }
    }
