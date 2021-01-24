     public static void ConcatIntegers() {
        Console.WriteLine(string.Concat(Enumerable
          .Range(0, 6)
          .Select(i => $"{i:d2}"))); // each item in 2 digits format
        Console.Read();
      }
