    public static IEnumerable<ITreeNodeDefinition> DepthFirstSearch(ITreeNodeDefinition root, int? relationshipId)
    {
        var stack = new Stack<ITreeNodeDefinition>();
        stack.Push(root);
        while(stack.Count > 0)
        {
            var current = stack.Pop();
            if (current.RelationshipId == relationshipId)
                yield return current;
            foreach(var node in current.Nodes)
                stack.Push(node);
        }
    }
