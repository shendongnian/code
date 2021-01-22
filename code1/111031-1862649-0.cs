    using System.Xml;
    public class Form1
    {
    
    XmlDocument Doc1;
    XmlDocument Doc2;
    
    string Doc1Path = "C:\\XmlDoc1.xml";
    
    private void Form1_Load(object sender, System.EventArgs e)
    {
        
        Doc1 = new XmlDocument();
        Doc2 = new XmlDocument();
        
        Doc1.Load(Doc1Path);
        Doc2.Load("C:\\XmlDoc2.xml");
        
        Compare();
        
        Doc1.Save(Doc1Path);
        
    }
    
    public void Compare()
    {
        
        foreach (XmlNode ChNode in Doc2.ChildNodes) {
            CompareLower(ChNode);
        }
        
    }
    
    public void CompareLower(XmlNode NodeName)
    {
        
        foreach (XmlNode ChlNode in NodeName.ChildNodes) {
            
            if (ChlNode.Name == "#text") {
                continue;
            }
            
            string Path = CreatePath(ChlNode);
            
            if (Doc1.SelectNodes(Path).Count == 0) {
                XmlNode TempNode = Doc1.ImportNode(ChlNode, true);
                Doc1.SelectSingleNode(Path.Substring(0, Path.LastIndexOf("/"))).AppendChild(TempNode);
                Doc1.Save(Doc1Path);
            }
            else {
                CompareLower(ChlNode);
                Doc1.Save(Doc1Path);
            }
            
        }
        
    }
    
    public string CreatePath(XmlNode Node)
    {
        
        string Path = "/" + Node.Name;
        
        while (!(Node.ParentNode.Name == "#document")) {
            Path = "/" + Node.ParentNode.Name + Path;
            Node = Node.ParentNode;
        }
        Path = "/" + Path;
        return Path;
        
    }
    
