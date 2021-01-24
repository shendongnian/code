    // p is because you cant used fixed in a lambda
    public static unsafe byte* p;
    
    // AggressiveInlining to compile in line if possible
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Do(int i)
    {
       if (*(p + i) > 10) *(p + i) = 255;
    }
    
    public static unsafe void Main()
    {
       int x = 10, y = 10, z = 1;  
       var data = new byte[x, y, z];
    
       fixed (byte* pbytes = data)
       {
          p = pbytes;
          Parallel.For(0, x * y,
             new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount},
             UnsafeOps.Do);
       }
    }
