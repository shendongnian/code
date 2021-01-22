    using System;
     
    class ArrayClear
    {
     
       public static void Main()
       {
          int[] integers = { 1, 2, 3, 4, 5 };
          DumpArray ("Before: ", integers);
          Array.Clear (integers, 1, 3);
          DumpArray ("After:  ", integers);
       }
        
       public static void DumpArray (string title, int[] a)
       {
          Console.Write (title);
          for (int i = 0; i < a.Length; i++ )
          {
             Console.Write("[{0}]: {1, -5}", i, a[i]);
          }
          Console.WriteLine();
       }
    }
