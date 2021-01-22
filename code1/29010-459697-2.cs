    class Test : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    
        public void Add(int i) { }
        public void Add(int i, string s) { }
    }
