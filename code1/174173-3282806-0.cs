    using System;
    class ABC
    {
      public int a,b;
      public ABC(int x, int y)
      {
        a = x;
        b = y;
      }
      public static ABC operator ++(ABC x)
      {
        x.a++;
        x.b++;
        return x;
      }
    }
    class Program
    {
        static void Main()
        {
            var a = new ABC(5, 6);
            if ((a.a != 5) || (a.b != 6)) Console.WriteLine(".ctor failed");
            var post = a++;
            if ((a.a != 6) || (a.b != 7)) Console.WriteLine("post incrementation failed");
            if ((post.a != 5) || (post.b != 6)) Console.WriteLine("post incrementation result failed");
            var pre = ++a;
            if ((a.a != 7) || (a.b != 8)) Console.WriteLine("pre incrementation failed");
            if ((pre.a != 7) || (pre.b != 8)) Console.WriteLine("pre incrementation result failed");
            Console.Read();
        }
    }
