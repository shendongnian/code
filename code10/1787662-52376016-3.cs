    public static IEnumerable<ITreeNodeDefinition> DepthFirstSearch(this ITreeNodeDefinition root)
        => DepthFirstSearch(root, t => true);
    public static IEnumerable<ITreeNodeDefinition> DepthFirstSearch(this ITreeNodeDefinition root, Func<ITreeNodeDefinition, bool> selector)
    {
        var stack = new Stack<ITreeNodeDefinition>();
        stack.Push(root);
        while (stack.Any())
        {
            var current = stack.Pop();
            if (selector(current))
                yield return current;
            foreach (var node in current.Nodes)
                stack.Push(node);
        }
    }
