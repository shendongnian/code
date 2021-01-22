    for (int i = 0; i < 9*9; ++i)
    {
      int a = i / 9 + 1;
      int b = i % 9 + 1;
      Console.Writeline(a.ToString() + "*" + b.ToString() + "=" + (a*b).ToString());
    }
