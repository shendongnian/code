    private void CheckAllParentNodes(TreeNode treeNode, bool nodeChecked)
    {
       TreeNode parentNode = treeNode.Parent;
       while (parentNode != null)
       {
         parentNode.Checked = nodeChecked;
         parentNode = parentNode.Parent;
       }
    }
