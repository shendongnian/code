    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Path to your xml file");
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("Row", "http://www.namespace.com/");    // <= Replace your namespace here that start with "xmlns:Row="http://www.namespace.com/"" in root of document
            XmlNodeList nodes = doc.SelectNodes("//Doc//Entries//Entry//*", ns);
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node.InnerText);
            }
            Console.ReadLine();
        }
    }
