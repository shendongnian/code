    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    class Program {
      static void Main(string[] args) {
        var arr = new double[10 * 1024 * 1024];
        for (int loop = 1; loop < 20; ++loop) {
          var sw1 = Stopwatch.StartNew();
          for (int ix = 0; ix < arr.Length; ++ix)
            arr[ix] = double.NaN;
          sw1.Stop();
          var sw2 = Stopwatch.StartNew();
          memset(arr, 0xff, 8 * arr.Length);
          sw2.Stop();
          Console.WriteLine("Loop: {0}, memset: {1}", sw1.ElapsedMilliseconds, sw2.ElapsedMilliseconds);
        }
        Console.ReadLine();
      }
      [DllImport("msvcrt.dll")]
      private static extern void memset(double[] array, int value, int cnt);
    }
