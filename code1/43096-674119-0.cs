    TreeNode root = new TreeNode();
    TreeNode node = root;
    treeView1.Nodes.Add(root);
    
     foreach (string filePath in myList) // myList is your list of paths
     {
        node = root;
        foreach (string pathBits in filePath.Split('/'))
        {
          node = AddNode(node, pathBits);
        }
     }
    
    
    private TreeNode AddNode(TreeNode node, string key)
    {
        if (node.Nodes.ContainsKey(key))
        {
            return node.Nodes[key];
        }
        else
        {
            return node.Nodes.Add(key, key);
        }
    }
