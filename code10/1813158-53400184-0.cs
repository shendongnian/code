    private void CopyTreeViewToClipboard(TreeView treeView)
    {
        // Make a StringBuilder to store the text of each individual node
        var treeViewStringBuilder = new StringBuilder();
        // Initiate the recursive method
        GetTreeViewNodesText(treeView.Nodes, treeViewStringBuilder);
        // because StringBuilder is a reference type we do not need use a return value 
        //   and we can copy to clipboard using the already existing reference
        Clipboard.SetText(treeViewStringBuilder.ToString());
    }
    private void GetTreeViewNodesText(TreeNodeCollection nodesInCurrentLevel, StringBuilder sb, int level = 0)
    {
        foreach (TreeNode currentNode in nodesInCurrentLevel)
        {
            // Add some padding (spaces) in front to display the current level
            sb.Append(new string(' ', level * 2));
            // Add the text and terminate the line \n\r
            sb.AppendLine(currentNode.Text);
            // Recursion happens here, it's level + 1 instead of level++ because we
            //   do not want to alter the level for the next nodes in nodesInCurrentLevel
            GetTreeViewNodesText(currentNode.Nodes, sb, level + 1);
        }
    }
