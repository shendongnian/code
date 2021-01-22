    //depth search on TreeView
    
    TreeNode node = trv.Nodes[0];
    Stack<TreeNode> list = new Stack<TreeNode>();
    list.Push(node);
    while (list.Count > 0)
    {
        while (node.Nodes.Count > 0)
        {
            list.Push(node.Nodes[0]);
            node = node.Nodes[0];
        }
        //Will always have a leaf here as the current node. The leaf is not pushed.
        //If it has a sibling, I will try to go deeper on it.
        if (node.NextNode != null)
        {
            node = node.NextNode;
            continue;
        }
        //If it does NOT have a sibling, I will pop as many parents I need until someone
        //has a sibling, and go on from there.
        while (list.Count > 0 && node.NextNode == null)
        {
            node = list.Pop();
        }
        if (node.NextNode != null) node = node.NextNode;
    }
    
    //broadth search on TreeView
    
    Queue<TreeNode> list = new Queue<TreeNode>();
    foreach(TreeNode node in trv.Nodes)
    {
        list.Enqueue(node);
    }
    foreach(TreeNode node in list)
    {
        foreach(TreeNode childNode in node.Nodes)
        {
            list.Enqueue(childNode);
        }
    }
