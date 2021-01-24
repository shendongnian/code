    public void RegisterParentRecursive(Example parent)
    {
        foreach(var child in parent.Children)
        {
            child.Parent = parent;
            RegisterParentRecursive(child);
        }
    }
