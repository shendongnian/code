    public class DummyCollection : IEnumerable
    {
        IEnumerable.GetEnumerator()
        {
            throw new InvalidOperationException("Not a real collection!");
        }
        public void Add(string x)
        {
            Console.WriteLine("Called Add(string)");
        }
        public void Add(int x, int y)
        {
            Console.WriteLine("Called Add(int, int)");
        }
    }
