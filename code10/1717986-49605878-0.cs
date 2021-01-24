    public class MyNonList : IEnumerable<int>
    {
        IEnumerable<int> _inner;
    
        public MyNonList(IEnumerable<int> inner)
        {
            _inner = inner;
        }
    
        public MyNonList Multiply(int n)
        {
            return new MyNonList(_inner.Select(i => i * n));
        }
    
        public IEnumerator<int> GetEnumerator() => _inner.GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_inner).GetEnumerator();
    }
    
    
    public static class Extensions
    {
        // Convert from IEnumerable<int> to MyList.
        public static MyNonList ToMyNonList(this IEnumerable<int> items)
        {
            return new MyNonList(items);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create a large list.
            var list = new List<int>();
            for (int i = 0; i < 1000000; ++i)
                list.Add(i);
            var myList = new MyNonList(list);
    
            // Call the MyList.Multiply method.
            MyNonList myList2 = myList.Skip(100).ToMyNonList().Multiply(5);
        }
    }
