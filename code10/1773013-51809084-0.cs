    interface ILevel
    {
        int Level { get; set; }
    }
    public static IEnumerable<TNode> DfsIterativeTraverse<TNode>(this TNode node, Func<TNode, IEnumerable<TNode>> childNodeSelectors)
        where TNode : class, ILevel
    {
        if (node == null)
        {
            yield break;
        }
    
        var currentLevel = 0;
        node.Level = 0;
    
        var stack = new Stack<TNode>();
        stack.Push(node);
    
        while (stack.Any())
        {
            var top = stack.Pop();
            foreach (var child in childNodeSelectors(top))
            {
                child.Level = top.Level + 1;
                stack.Push(child);
            }
            yield return top;
        }
    }
