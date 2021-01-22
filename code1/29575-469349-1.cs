    public event EventHandler NodeAdded;
    public void AddNode(TreeViewNode node)
    {
        Nodes.Add(node);
        if (NodeAdded != null)
        {
            NodeAdded(this, EventArgs.Empty);
        }
    }
