    public static IEnumerable<ITreeNodeDefinition> DepthFirstSearch(ITreeNodeDefinition root, Func<ITreeNodeDefinition, bool> predicate)
    {
        var stack = new Stack<ITreeNodeDefinition>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (predicate(current))
                yield return current;
            foreach (var node in current.Nodes)
                stack.Push(node);
        }
    }
