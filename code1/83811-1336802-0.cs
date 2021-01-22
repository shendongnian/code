    private void replaceInTreeView()
    {
        TreeView myTree = new TreeView();
        ReplaceTextInAllNodes(myTree.Nodes, "REPLACEME", "WITHME");
    }
    private void ReplaceTextInAllNodes(TreeNodeCollection treeNodes, string textToReplace, string newText)
    {
        foreach(TreeNode aNode in treeNodes)
        {
            aNode.Text = aNode.Text.Replace(textToReplace, newText);
            if(aNode.ChildNodes.Count > 0)
                ReplaceTextInAllNodes(aNode.ChildNodes, textToReplace, newText);
            }
        }
    }
