    class Program
    {
        static void Main()
        {
            new Foo { 1, "abc", { 2, "def" } };
        }
    }
    class Foo : IEnumerable
    {
        public void Add(int a) { }
        public void Add(string b) { }
        public void Add(int a, string b) { }
        // must implement this!! (but never called)
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
    }
