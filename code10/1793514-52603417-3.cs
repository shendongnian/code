     public static void ConcatIntegers() {
       // "000102030405" since we apply "d2" format (each number reprsented with 2 digits)
       Console.WriteLine(string.Concat(Enumerable
         .Range(0, 6)
         .Select(i => $"{i:d2}"))); // each item in 2 digits format
       Console.Read();
     }
