    class Program {
       static void Main() { Test<int>(); }
       static void Test<T>() {
          Console.WriteLine(typeof(List<T>)); // Print out the type name
       }
    }
