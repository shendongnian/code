    private static void PrintAll<T>(IEnumerable<T> list)
    {
         foreach (var item in list)
         {
              Console.WriteLine(item.ToString());
         }
    }
    
    static void Main()
    {
         List<int> numbers = Enumerable.Range(1, 10).ToList();
         PrintAll(numbers);
    }
