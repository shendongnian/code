    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Documents and Settings\\Umaid\\My Documents\\Visual Studio 2008\\Projects\\EditXML\\EditXML\\testing.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var itemNode = doc.SelectSingleNode("rule/one-of/item");
            if (itemNode != null)
            {
                itemNode.InnerText = "Umaid";
            }
            doc.Save(path);
        }
    }
