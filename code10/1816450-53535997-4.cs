    static unsafe class UnsafeOps
    {
       public static byte* p;
    
       [MethodImpl(MethodImplOptions.AggressiveInlining)]
       public static void Do(int i)
       {
          if (*(p + i) > 10) *(p + i) = 255;
       }
    }
    
    public static unsafe void Main()
    {
       int x = 10, y = 10, z = 1;
    
       var data = new byte[x, y];
    
       fixed (byte* pbytes = data)
       {
          UnsafeOps.p = pbytes;
          Parallel.For(0, x * y,
             new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount},
             UnsafeOps.Do);
       }
    }
