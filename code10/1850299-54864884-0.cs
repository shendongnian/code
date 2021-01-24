    class Test
    {
      [DllExport("Add", CallingConvention = CallingConvention.Cdecl)]
      public static int Add(int a, int b)
      {
         return a + b;
      } 
    }
