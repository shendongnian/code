    public static IEnumerable<T> TraverseDepthFirst<T>(T root, Func<T, IEnumerable<T>> childrenSelector)
    {
        if (childrenSelector == null) throw new ArgumentNullException(nameof(childrenSelector));
        return _(); IEnumerable<T> _()
        {
            var stack = new Stack<T>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                yield return current;
                // because a stack pops the elements out in LIFO order, we need to push them in reverse
                // if we want to traverse the returned list in the same order as was returned to us
                foreach (var child in childrenSelector(current).Reverse())
                    stack.Push(child);
            }
        }
    }
