      using System.Linq;
      ...
      // static: we don't use "this" in the method
      public static void ConcatIntegers() {
        // Concatenate range of 0..5 integers: "012345"
        Console.WriteLine(string.Concat(Enumerable
          .Range(0, 6))); // 6 - we want 6 numbers: 0..5
        Console.Read();
      }
