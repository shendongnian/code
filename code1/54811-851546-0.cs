    private void populateTreeControl(
                System.Xml.XmlNodeList xmlNodes, 
                System.Windows.Forms.TreeNodeCollection treeNodes)
    {
      foreach (System.Xml.XmlNode node xmlNodes)
      {
        string text = "";
        if (node.Value != null) 
          text = node.Value;
        else if (node.Attributes.Count > 0)
          text = node.Attributes[0].Value;
        else 
          text = node.Name;
        
        TreeNode new_child = new TreeNode(text);
        treeNodes.Add(new_child);
        string xpath = "parameter[@name='Host' or @name='Port']";
        populateTreeControl(xmlNodes.SelectNodes(xpath), new_child.Nodes);
      }
    }
