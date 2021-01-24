        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeView tree = (TreeView)sender;
            TreeNode node = tree.SelectedNode;
            bool isExpanded = Boolean.Parse(node.Expanded.ToString());
            if (isExpanded)
                node.Collapse();
            else
                node.Expand();
            tree.SelectedNode.Selected = false;
        } 
