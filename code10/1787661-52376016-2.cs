    public IEnumerable<ITreeNodeDefinition> DepthFirstSearch(int? relationshipId)
    {
        var stack = new Stack<ITreeNodeDefinition>();
        stack.Push(this);
        while(stack.Any())
        {
            var current = stack.Pop();
            if (current.RelationshipId == relationshipId)
                yield return current;
            foreach(var node in current.Nodes)
                stack.Push(node);
        }
    }
