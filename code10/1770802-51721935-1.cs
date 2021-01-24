    class MyCollection
    {
        int count = 0;
        void Reset()
        {
            count = 0;
        }
        bool MoveNext()
        {
            count++;
            return count < 5;
        }
        public int Current => 42;
        public IEnumerator<int> GetEnumerator()
        {
            Reset();
            while (MoveNext())
                yield return Current;
        }
    }
