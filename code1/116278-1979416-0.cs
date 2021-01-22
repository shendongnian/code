    StringBuilder sb1 = new StringBuilder(1024);
    for (int i = 0; i < 992; i++)
        sb1.Append('a');
    Console.WriteLine(sb1.ToString());
    Console.WriteLine("{0}",sb1.Length);
    StringBuilder sb2 = new StringBuilder();
    for (int i = 0; i < 1024; i++)
        sb2.Append('b');
    Console.WriteLine(sb2.ToString());
    Console.WriteLine("{0}",sb2.Length);
    sb1.Append(sb2.ToString());
    Console.WriteLine(sb1.ToString());
    Console.WriteLine("{0}",sb1.Length);
