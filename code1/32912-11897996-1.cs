    public struct EnumeratedInstance<T>
    {
        public long cnt;
        public T item;
    }
    public static IEnumerable<EnumeratedInstance<T>> Enumerate<T>(this IEnumerable<T> collection)
    {
        long counter = 0;
        foreach (var item in collection)
        {
            yield return new EnumeratedInstance<T>
            {
                cnt = counter,
                item = item
            };
            counter++;
        }
    }
