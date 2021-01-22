    public static class Ext
    {
        private class StreamBuffer<T> : IEnumerable<T>
        {
            private int head = 0;
            private bool filled = false;
            private T[] stream;
            public int Size { get; private set; }
            public StreamBuffer(int size)
            {
                Size = size;
                stream = new T[Size];
            }
            public void Add(T item)
            {
                stream[head] = item;
                head += 1;
                if (head >= Size)
                {
                    head = 0;
                    filled = true;
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                int start = filled ? head : 0;
                int size = filled ? Size : head;
                for (int i = 0; i < size; i += 1)
                {
                    int p = (start + i) % Size;
                    yield return stream[p];
                }
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
