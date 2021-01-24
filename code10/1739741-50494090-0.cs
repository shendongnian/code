    using System;
    
    static class P
    {
      static void Main()
      {
        var a = new sbyte[] { -7, -3, 8, 11, };
        var hack = (byte[])(Array)a;
        Console.WriteLine(string.Join("\r\n", hack));
      }
    }
