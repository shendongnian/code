    public static class LinkedListExtensions   
    {
        public static void AppendRange<T>(this LinkedList<T> source,
                                          IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                source.AddLast(item);
            }
        }
    }
