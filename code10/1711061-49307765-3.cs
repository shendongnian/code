    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    
    public static class Program
    {
        public static void Main()
        {
            var items = new[] { "item1", "item2", "item3" };
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, bag.Add);
        }
    }
