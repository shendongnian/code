    private void populateTreeControl(
      System.Xml.Node context, 
      System.Windows.Forms.TreeNodeCollection treeNodes,
      List<string> xpath,
      int depth
    )
    {
      if (xpath.Count > depth) {
        foreach (System.Xml.XmlNode xmlNode in context.SelectNodes(xpath[depth]))
        {
          string text = "";
          if (xmlNode.Value != null) 
            text = xmlNode.Value;
          else if (xmlNode.Attributes.Count > 0)
            text = xmlNode.Attributes[0].Value;
          else 
            text = xmlNode.Name;
        
          TreeNode new_child = new TreeNode(text);
          treeNodes.Add(new_child);
          populateTreeControl(xmlNode, new_child.Nodes, xpath, depth + 1);
        }
      }
    }
