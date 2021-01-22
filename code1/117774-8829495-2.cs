    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> subjects, Func<T, IEnumerable<T>> selector)
    {
        if (subjects == null)
            yield break;
        var stack = new Stack<IEnumerator<T>>();
        stack.Push(subjects.GetEnumerator());
        while (stack.Count > 0)
        {
            var en = stack.Peek();
            if (en.MoveNext())
            {
                var subject = en.Current;
                yield return subject;
                stack.Push(selector(subject).GetEnumerator());
            }
            else 
            {
                stack.Pop().Dispose();
            }
        }
    }
