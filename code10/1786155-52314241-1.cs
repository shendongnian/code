    class TestClass2 : IEnumerable<(int, int)>
    {
        private List<int> Numbers = new List<(int, int)> ();
    
        public void Add(int x, int y)
        {
            Numbers.Add((x, y));
        }
        // implement IEnumerable methods down here ...
        public IEnumerator<(int, int)> GetEnumerator() => Numbers.GetEnumerator();
        // etc ...
    }
