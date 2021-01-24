    class TestClass : IEnumerable<int>
    {
        private List<int> Numbers = new List<int> ();
    
        public void Add(int n)
        {
            Numbers.Add(n);
        }
        // implement IEnumerable methods down here ...
        public IEnumerator<int> GetEnumerator() => Numbers.GetEnumerator();
        // etc ...
    }
