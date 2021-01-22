    class MyContainer : IEnumerable<int>
    {
        private int max = 0;
        public MyContainer(int max)
        {
            this.max = max;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for(int i = 0; i < max; ++i)
                yield return i;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
