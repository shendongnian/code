    class CircularArray<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int index;
        public CircularArray(T[] array)
        {
            this.array = array;
        }
        public T Current
        {
            get { return array[index]; }
        }
        public void Dispose()
        {
        }
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            index++;
            if (index == array.Length)
                index = 0;
            return true;
        }
        public void Reset()
        {
            index = 0;
        }
    }
