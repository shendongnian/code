    class Test : IEnumerable<int>
    {
        public SomethingEnumerator GetEnumerator()
        {
            //this one is called
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
        }
    }
