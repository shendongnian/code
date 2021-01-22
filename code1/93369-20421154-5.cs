    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    static void Main(string[] args) {
      Console.WriteLine("This program generates prime sequences.\r\n");
      var n = 10000000u;
      var elpsd = -DateTime.Now.Ticks;
      var count = 0; var lastp = 0u;
      foreach (var p in primes(n)) { if (p > n) break; ++count; lastp = (uint)p; }
      elpsd += DateTime.Now.Ticks;
      Console.WriteLine(
        "{0} primes found <= {1}; the last one is {2} in {3} milliseconds.",
        count, n, lastp,elpsd / 10000);
      Console.Write("\r\nPress any key to exit:");
      Console.ReadKey(true);
      Console.WriteLine();
    }
