       class Program
        {
            static void Main(string[] args)
            {
                List<int> ints = new List<int>();
    
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Mod: {0}", i % 2 );
                    Console.WriteLine("BitWise: {0}", i & 1 );
    
                    ints.Add(i);
                    Console.WriteLine("Extension: {0}", ints.IsEven() );
                }
                Console.ReadLine();
            }
       }
    
        public static class ListExtensions
        {
            public static bool IsEven<T>(this ICollection<T> collection)
            {
                return (collection.Count%2) == 0;
            }
    
            public static bool IsOdd<T>(this ICollection<T> collection)
            {
                return (collection.Count%2) != 0;
            }
        }
