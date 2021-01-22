    class CircularArray<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int index = -1;
        public T Current { get; private set; }
        public CircularArray(T[] array)
        {
            Current = default(T);
            this.array = array;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            if (++index >= array.Length)
                index = 0;
            Current = array[index];
            return true;
        }
        public void Reset()
        {
            index = -1;
        }
        public void Dispose() { }
    }
