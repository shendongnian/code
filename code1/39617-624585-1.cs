    TreeNodeCollection nodes;
    if(e.Node.Parent != null)
    {
        nodes = e.Node.Parent.Nodes;
    }
    else
    {
        nodes = e.Node.TreeView.Nodes;
    }
    
