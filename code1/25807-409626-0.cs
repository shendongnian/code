    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String[] list = new String[] { "Word1", "Word2", "Word3" };
    
            list.ForEach<String>(p => Console.WriteLine(p));
            list.ForEach(delegate(String p) { Console.WriteLine(p); });
        }
    }
