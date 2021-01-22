    static void Test()
    {
      object o1 = "a";
      object o2 = new string("a".ToCharArray());
      string o3 = "a";
      string o4 = new string("a".ToCharArray());
      object o5 = "a"; // Compiler optimization addr(o5) = addr(o6)
      object o6 = "a";
      string o7 = "a"; // Compiler optimization addr(o7) = addr(o8)
      string o8 = "a";
      Console.WriteLine("Enter same text 4 times:");
      object o9 = Console.ReadLine();
      object o10 = Console.ReadLine();
      string o11 = Console.ReadLine();
      string o12 = Console.ReadLine();
      Console.WriteLine("object arr   o1  == o2  ? " + ( o1 == o2 ).ToString());
      Console.WriteLine("string arr   o3  == o4  ? " + ( o3 == o4 ).ToString());
      Console.WriteLine("object const o5  == o6  ? " + ( o5 == o6 ).ToString());
      Console.WriteLine("string const o7  == o8  ? " + ( o7 == o8 ).ToString());
      Console.WriteLine("object cnsl  o9  == o10 ? " + ( o9 == o10 ).ToString());
      Console.WriteLine("string cnsl  o11 == o12 ? " + ( o11 == o12 ).ToString());
    }
