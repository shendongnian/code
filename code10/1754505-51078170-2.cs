    public static class TreeVisitor
    {
        public static IEnumerable<TNodeType> WidthTraversal<TNodeType>(TNodeType root, Func<TNodeType, IEnumerable<TNodeType>> getChildNodesFunc)
            where TNodeType : class
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (getChildNodesFunc == null)
            {
                throw new ArgumentNullException(nameof(getChildNodesFunc));
            }
            var visited = new HashSet<TNodeType>();
            var queue = new Queue<TNodeType>();
            yield return root;
            visited.Add(root);
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();
                foreach (var child in getChildNodesFunc(parent))
                {
                    if (child == default(TNodeType))
                        continue;
                    if (!visited.Contains(child))
                    {
                        yield return child;
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
