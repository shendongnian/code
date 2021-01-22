    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    class Program {
      static void Main(string[] args) {
        byte[] arr1 = new byte[50 * 1024 * 1024];
        byte[] arr2 = new byte[50 * 1024 * 1024];
        var sw = Stopwatch.StartNew();
        bool equal = memcmp(arr1, arr2, arr1.Length) == 0;
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        Console.ReadLine();
      }
      [DllImport("msvcrt.dll")]
      private static extern int memcmp(byte[] arr1, byte[] arr2, int cnt);
    }
