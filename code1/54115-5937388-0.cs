    //clear background
    RadTreeNodeCollection nodes = rtrvNetworkAll.Nodes;
    foreach (RadTreeNode n in nodes)
    {
            this.ClearRecursive(n);
    }
    //search a node with the build in find function
    foreach (RadTreeNode n in nodes)
    {
            this.FindRecursive(n);
    }
    // recursively move through the treeview nodes
    private void FindRecursive(RadTreeNode treeNode)
    {
            foreach (RadTreeNode tn in treeNode.Nodes)
            {
                    // if the text properties match, color the item
                    if (tn.Text == this.txtSearch.Text)
                    {
                        tn.BackColor = Color.Yellow;
                    }
                    FindRecursive(tn);
            }
    }
    private void ClearRecursive(RadTreeNode treeNode)
    {
           foreach (RadTreeNode tn in treeNode.Nodes)
           {
                    tn.BackColor = Color.White;
                    ClearRecursive(tn);
           }
    }    
