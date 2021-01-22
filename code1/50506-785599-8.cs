    int? a = 0;
    Console.WriteLine(a.GetRealType() == typeof(int?));         // True
    Console.WriteLine(a.GetRealType() == typeof(int));          // False
    int b = 0;
    Console.WriteLine(b.GetRealType() == typeof(int));          // True
    Console.WriteLine(b.GetRealType() == typeof(int?));         // False
    DateTime? c = DateTime.Now;
    Console.WriteLine(c.GetRealType() == typeof(DateTime?));    // True
    Console.WriteLine(c.GetRealType() == typeof(DateTime));     // False
    DateTime d = DateTime.Now;
    Console.WriteLine(d.GetRealType() == typeof(DateTime));     // True
    Console.WriteLine(d.GetRealType() == typeof(DateTime?));    // False
