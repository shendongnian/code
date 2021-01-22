    using System;
    using System.Drawing;
    using System.Linq;
    namespace UlamsSpiral
    {
       public static class Program
       {
          public static void Main()
          {
             Int32 width = 60;
             Int32 height = 60;
    
             Console.SetWindowSize(Math.Min(width, 120), Math.Min(height, 60));
             Console.SetBufferSize(width, height);
    
             Int32 limit = (Int32)Math.Pow(Math.Min(width, height) - 2, 2);
    
             for (Int32 n = 1; n <= limit; n++)
             {
                if (n.IsPrime())
                {
                   Point point = NumberToPoint(n - 1, width / 2 - 1, height / 2);
                   Console.SetCursorPosition(point.X, point.Y);
                   Console.Write('■');
                }
             }
    
             Console.ReadLine();
          }
    
          private static Point NumberToPoint(Int32 n, Int32 x0, Int32 y0)
          {
             Int32[,] c = { { -1, 0, 0, -1, 1, 0 }, { -1, 1, 1, 1, 0, 0 }, { 1, 0, 1, 1, -1, -1 }, { 1, -1, 0, -1, 0, -1 } };
    
             Int32 square = (Int32)Math.Floor(Math.Sqrt(n / 4));
    
             Int32 index;
             Int32 side = (Int32)Math.DivRem(n - 4 * square * square, 2 * square + 1, out index);
    
             Int32 x = c[side, 0] * square + c[side, 1] * index + c[side, 2];
             Int32 y = c[side, 3] * square + c[side, 4] * index + c[side, 5];
    
             return new Point(x + x0, y + y0);
          }
    
          private static Boolean IsPrime(this Int32 n)
          {
             if (n < 3) return (n == 2);
             return Enumerable.Range(2, (Int32)Math.Sqrt(n)).All(m => n % m != 0);
          }
       }
    }
