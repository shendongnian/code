    protected void TreeView1_PreRender(object sender, EventArgs e)
    {
        SelectCurrentPageTreeNode(TreeView1);
    }
    private void SelectCurrentPageTreeNode(TreeView tvTreeView)
    {
        tvTreeView.CollapseAll();
        if (Request.Url.PathAndQuery != null)
        {
            ExpandTreeViewNodes(tvTreeView, Request.Url.PathAndQuery);
        }
    }
    private TreeNode ExpandTreeViewNodes(TreeView tvTreeView, string sPathAndQuery)
    {
        if (tvTreeView != null)
        {
            if (!string.IsNullOrEmpty(sPathAndQuery))
            {
                sPathAndQuery = sPathAndQuery.ToLower();
                {
                    TreeNode tnWorkTreeNode = null;
                    for (int iLoop = 0; iLoop < tvTreeView.Nodes.Count; iLoop++)
                    {
                        tvTreeView.Nodes[iLoop].Expand();
                        tvTreeView.Nodes[iLoop].Selected = true;
                        if (tvTreeView.Nodes[iLoop].NavigateUrl.ToLower() == sPathAndQuery)
                        {
                            return (tvTreeView.Nodes[iLoop]);
                        }
                        else
                        {
                            tnWorkTreeNode = ExpandTreeViewNodesR(tvTreeView.Nodes[iLoop], sPathAndQuery);
                        }
                        if (tnWorkTreeNode != null)
                        {
                            return (tnWorkTreeNode);
                        }
                        tvTreeView.Nodes[iLoop].Collapse();
                    }
                }
            }
        }
        return (null);
    }
    private static TreeNode ExpandTreeViewNodesR(TreeNode tvTreeNode, string sPathAndQuery)
    {
        TreeNode tnReturnTreeNode = null;
        if (tvTreeNode != null)
        {
            tvTreeNode.Expand();
            if (tvTreeNode.NavigateUrl.ToLower() == sPathAndQuery)
            {
                return (tvTreeNode);
            }
            else
            {
                tnReturnTreeNode = null;
                for (int iLoop = 0; iLoop < tvTreeNode.ChildNodes.Count; iLoop++)
                {
                    tvTreeNode.ChildNodes[iLoop].Selected = true;
                    tnReturnTreeNode = ExpandTreeViewNodesR(tvTreeNode.ChildNodes[iLoop], sPathAndQuery);
                    if (tnReturnTreeNode != null)
                    {
                        return (tnReturnTreeNode);
                    }
                }
                tvTreeNode.Collapse();
            }
        }
        return (null);
    }
