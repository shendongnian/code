    public TreeNode(TreeNode parent)
    {
        this.parent = parent;
        if (parent != null)
        {
            parent.AddChild(this);
        }
    }
