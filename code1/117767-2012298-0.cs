    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> subjects,
        Func<T, IEnumerable<T>> selector)
    {
        if (subjects == null)
        {
            yield break;
        }
    
        Queue<T> stillToProcess = new Queue<T>(subjects);
        while (stillToProcess.Count > 0)
        {
            T item = stillToProcess.Dequeue();
            yield return item;
            foreach (T child in selector(item))
            {
                stillToProcess.Enqueue(child);
            }
        }
    }
