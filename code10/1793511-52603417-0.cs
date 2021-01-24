      using System.Linq;
      ...
      public static void ConcatIntegers() {
        // Concatenate range of 0..5 integers
        Console.WriteLine(string.Concat(Enumerable
          .Range(0, 6)));
        Console.Read();
      }
