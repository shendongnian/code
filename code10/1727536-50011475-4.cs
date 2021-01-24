    class C {
      public static string FullName = "Hello";
    }
    ...
    Type c = C;
    Console.WriteLine(c.FullName); // "C"
    Console.WriteLine(C.FullName); // "Hello"
