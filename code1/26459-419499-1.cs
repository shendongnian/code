    public class Counter<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public Counter(IEnumerable<T> source)
        {
            mSource = source;
            Count = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var T in mSource)
            {
                Count++;
                yield return T;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var T in mSource)
            {
                Count++;
                yield return T;
            }
        }
        private IEnumerable<T> mSource;
    }
