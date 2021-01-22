    static IEnumerable<T> Traversal<T>(
        T item,
        Func<T, IEnumerable<T>> children)
    {
        var seen = new HashSet<T>();
        var stack = new Stack<T>();
        seen.Add(item);
        stack.Push(item); 
        yield return item;
        while(stack.Count > 0)
        {
            T current = stack.Pop();
            foreach(T newItem in children(current))
            {
                if (!seen.Contains(newItem))
                {
                    seen.Add(newItem);
                    stack.Push(newItem);
                    yield return newItem;
                }
            }
        } 
    }
