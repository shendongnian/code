    class TestClass : IEnumerable<int>
    {
        private List<int> Numbers = new List<int> ();
    
        public void Add(int n)
        {
            Numbers.Add(n);
        }
        public IEnumerator<int> GetEnumerator()
        {
            return Numbers.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
