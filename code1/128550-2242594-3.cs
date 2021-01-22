    object[] a = new string[10];
    object[] b = new string[10];
    for(int i = 0; i < 10; i++) {
        a[i] = i.ToString();
        b[i] = (i + 5).ToString();
    }
    object[] c = Merge(a, b);
    Console.WriteLine(c.Length);
    Console.WriteLine(c.GetType());
    for (int i = 0; i < c.Length; i++) {
        Console.WriteLine(c[i]);
    }
  
