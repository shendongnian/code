    class Tree : IEnumerable
    {
        public string Value { get; set; }
        
        public void Add(Tree t) { ... }
        
        // Add this method
        public void Add(string s)
        {
            Add(new Tree { Value = s });
        }
        public IEnumerator GetEnumerator() { ... }
    }
