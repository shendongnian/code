    public void initiatingTree(string nameofFile, TreeView treeView1)
    {
        try
        {
            //Create XML document & load the XML file.
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(nameofFile);
    
            treeView1.Nodes.Clear();
    
            if (xmlDocument.DocumentElement != null)
            {
                TreeNode treeNodedoc = new TreeNode(xmlDocument.DocumentElement.Name);
    
                treeView1.Nodes.Add(treeNodedoc);
            }
        }
    }
