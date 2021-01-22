    static IEnumerable<Node> AllNodes(this Node node)
    {
        var stack = new Stack<Node>();
        stack.Push(node);
        while(stack.Count > 0)
        {
            var current = stack.Pop();
            yield return current;
            foreach(var child in current.Nodes)
                stack.Push(child);
        }
    }
