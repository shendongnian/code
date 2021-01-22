    using System;
    using System.Xml;
    
    public class Test
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager namespaces = new XmlNamespaceManager(doc.NameTable);
            namespaces.AddNamespace("ns", "urn:hl7-org:v3");
            doc.Load("test.xml");
            XmlNode idNode = doc.SelectSingleNode("/My_RootNode/ns:id", namespaces);
            string msgID = idNode.Attributes["extension"].Value;
            Console.WriteLine(msgID);
        }
    }
