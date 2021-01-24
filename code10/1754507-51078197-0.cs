    public Items FindByName(Items root, string targetName)
    {
        var stack = new Stack<Items>();
        stack.Push(root);
    
        Items node;
        while (true)
        {
            node = stack.Pop();
            if (node == null)
            {
                // not found ..
            }
            if (node.Name == targetName)
            {
                break;
            }
            foreach (var child in node.Children)
            {
                stack.Push(child);
            }
        }
        return node;
    }
