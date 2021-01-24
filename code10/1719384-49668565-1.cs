    private void CheckAllParentNodes(TreeNode treeNode, bool nodeChecked)
    {
       TreeNode parentNode = treeNode.Parent;
       while (parentNode != null)
       {
         // check if parent has still checked child nodes
         if (parent.Nodes.Any(n => n.Checked)) return;
         parentNode.Checked = nodeChecked;
         parentNode = parentNode.Parent;
       }
    }
