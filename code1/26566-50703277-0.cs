    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Test
    {
      private static void DoIt(IEnumerable<int> a)
      {
        Console.WriteLine(String.Join(" ", a));
    
        foreach (var x in a.Zip(a.Skip(1), (x, y) => Enumerable.Repeat(x, 1).Concat(Enumerable.Repeat(y, 1))).Zip(a.Skip(2), (xy, z) => xy.Concat(Enumerable.Repeat(z, 1))).Where((x, i) => i % 3 == 0))
          Console.WriteLine(String.Join(" ", x));
    
        Console.WriteLine();
      }
    	
      public static void Main()
      {
        DoIt(new int[] {1});
        DoIt(new int[] {1, 2});
        DoIt(new int[] {1, 2, 3});
        DoIt(new int[] {1, 2, 3, 4});
        DoIt(new int[] {1, 2, 3, 4, 5});
        DoIt(new int[] {1, 2, 3, 4, 5, 6});
      }
    }
