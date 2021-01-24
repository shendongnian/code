    public static IEnumerable<T> SkipUntilLast<T>(
        this IEnumerable<T> source, Func<T, bool> predicate)
    {
        var stack = new Stack<T>(count);
        foreach(var item in source.Reverse())
        {
            if (predicate(item))
                return stack;
            stack.Push(item);
        }
        return Enumerable.Empty<T>();
    }
