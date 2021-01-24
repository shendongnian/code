    static void Main(string[] args)
    {
      string s = "{abc}@{defgh}mner{123}";
      int i1, i2 = 0;
      while ((i1 = s.IndexOf('{', i2)) >= 0)
      {
        i2 = s.IndexOf('}', i1);
        // Here you can add Substring result to some list or assign it to a variable...
        Console.WriteLine(s.Substring(i1 + 1, i2 - i1 - 1));
      }
    }
