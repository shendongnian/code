    class Program
    {
        static void Main(string[] args)
        {
            var originalNumbers = new List<int> { 1, 2, 3, 4, 5, 6 };
    
            var list = new List<int>(originalNumbers);
            var collection = new Collection<int>(originalNumbers);
    
            originalNumbers.RemoveAt(0);
    
            DisplayItems(list, "List items: ");
            DisplayItems(collection, "Collection items: ");
    
            Console.ReadLine();
        }
    
        private static void DisplayItems(IEnumerable<int> items, string title)
        {
            Console.WriteLine(title);
            foreach (var item in items)
                Console.Write(item);
            Console.WriteLine();
        }
    }
