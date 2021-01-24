    namespace MySolution {
      class Program {
        static void Main(string[] args) {
          ...
    
          CombineTheLists(items, prices);
        }
    
        public static void CombineTheLists(List<string> items, List<double> prices) {
          for (int i = 0; i < Math.Min(items.Count, prices.Count); ++i)
            Console.WriteLine($"item {items[i]} costs {prices[i]:f2}"); // f2 - format string
        }
      }
    }
