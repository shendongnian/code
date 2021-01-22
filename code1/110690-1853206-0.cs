    using System;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("test.xml");        
            XmlNodeList list = doc.SelectNodes("/Packages/*");
            foreach (XmlNode node in list)
            {
                Console.WriteLine(node.Attributes["title"].Value);
            }
        }
    }
