    private void populateTreeControl(
      System.Xml.Node xmlNode, 
      System.Windows.Forms.TreeNodeCollection treeNodes,
      List<string> xpath,
      int depth
    )
    {
      if (xpath.Count > depth) {
        foreach (System.Xml.XmlNode node xmlNode.SelectNodes(xpath[depth])
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
          populateTreeControl(node, new_child.Nodes, xpath, depth + 1);
        }
      }
    }
