    public static class Ext
    {
        private class StreamBuffer<T> : IEnumerable<T>
        {
            private int head = -1, length = 0;
            private T[] stream;
            public int Size { get; private set; }
            public StreamBuffer(int size)
            {
                Size = size;
                stream = new T[Size];
            }
            public void Add(T item)
            {
                head = Wrap(head + 1);
                stream[head] = item;
                length = Math.Min(length + 1, Size);
            }
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0, p = Wrap(head - length + 1); i < length; i += 1, p = Wrap(p + 1))
                {
                    yield return stream[p];
                }
            }
            private int Wrap(int i)
            {
                int wrapped_upper = i % Size;
                if (wrapped_upper < 0)
                {
                    return Size + wrapped_upper;
                }
                return wrapped_upper;
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public static IEnumerable<T> TakeEnd<T>(this IEnumerable<T> enumerable, int count)
        {
            StreamBuffer<T> buffer = new StreamBuffer<T>(count);
            foreach (T t in enumerable)
            {
                buffer.Add(t);
            }
            return buffer;
        }
    }
