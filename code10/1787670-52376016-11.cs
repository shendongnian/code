    public static IEnumerable<ITreeNodeDefinition> BreadthFirstSearch(ITreeNodeDefinition root, Func<ITreeNodeDefinition, bool> predicate)
    {
        var queue = new Queue<ITreeNodeDefinition>();
        queue.Enqueue(root);
        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (predicate(current))
                yield return current;
            foreach (var node in current.Nodes)
                queue.Enqueue(node);
        }
    }
