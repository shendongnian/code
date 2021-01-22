    static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../Employees.xml");
        XmlNode root = doc.SelectSingleNode("*"); 
        ReadXML(root);
    }
    
    private static void ReadXML(XmlNode root)
    {
        if (root is XmlElement)
        {
            DoWork(root);
    
            if (root.HasChildNodes)
                ReadXML(root.FirstChild);
            if (root.NextSibling != null)
                ReadXML(root.NextSibling);
        }
        else if (root is XmlText)
        {}
        else if (root is XmlComment)
        {}
    }
    
    private static void DoWork(XmlNode node)
    {
        if (node.Attributes["Code"] != null)
            if(node.Name == "project" && node.Attributes["Code"].Value == "Orlando")
                Console.WriteLine(node.ParentNode.ParentNode.Attributes["Name"].Value);
    }
