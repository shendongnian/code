    static void primesttt(ulong top_number) {
      Console.WriteLine("Prime:  2");
      for (var i = 3UL; i <= top_number; i += 2) {
        var isPrime = true;
        for (uint j = 3u, lim = (uint)Math.Sqrt((double)i); j <= lim; j += 2) {
          if (i % j == 0)  {
            isPrime = false;
            break;
          }
        }
        if (isPrime) Console.WriteLine("Prime:  {0} ", i);
      }
    }
