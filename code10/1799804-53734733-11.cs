    public HashSet<T> ReachableNodes(T n)
    {
        var reachable = new HashSet<T>();
        if (nodes.Contains(n))
        {
            var stack = new Stack<T>();
            stack.Push(n);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!reachable.Contains(current))
                {
                    reachable.Add(current);
                    foreach (T n2 in Edges(current))
                        stack.Push(n2);
                }
            }
        }
        return reachable;
    }
