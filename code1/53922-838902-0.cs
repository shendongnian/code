    // Prints nothing
    Console.WriteLine(Type.GetType("System.Linq.Enumerable"));
    // Prints the type name (i.e. it finds it)
    Console.WriteLine(Type.GetType("System.Linq.Enumerable, System.Core, "
         + "Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
