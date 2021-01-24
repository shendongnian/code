      int n = 7;
      double step = 0.05; 
      double[] d = Enumerable
        .Range(-n / 2, n)
        .Select(i => i * step)
        .ToArray();
      Console.Write(string.Join("; ", d));
