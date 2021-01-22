    List<String> result = new List<String>();
    Stack<IEnumerator> nodeColls = new Stack<IEnumerator>();
    IEnumerator nodes = treeViewTab4DirectoryTree.Nodes.GetEnumerator();
    nodeColls.Push(null);
    while (nodes != null)
    {
        while (nodes.MoveNext())
        {
            result.add(nodes.Current.FullPath);
            if (nodes.Current.FirstNode != null)
            {
                nodeColls.Push(nodes);
                nodes = nodes.Current.Nodes.GetEnumerator();
            }
        }
        
        nodes = nodeColls.Pop();
    }
