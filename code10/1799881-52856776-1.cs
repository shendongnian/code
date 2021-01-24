    if(e.Action != TreeViewAction.Unknown)
    {
        if (e.Node.Parent == null) //if it's a parent node, make any children nodes match its checked state
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
                Map.FindFeatureLayer(node.Name).IsVisible = node.Checked;
            }
        }
        else //it's a child node
        {
            Map.FindFeatureLayer(e.Node.Name).IsVisible = e.Node.Checked;
        }
        //Map.Refresh();   // You may not need this if everything is immediate
    }
