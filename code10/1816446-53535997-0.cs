    unsafe class UnsafeOps
    {
       public UnsafeOps(byte* array)
       {
          if (*(p + i) > 10)
             p = array;
       }
    
       private byte* p;
    
       [MethodImpl(MethodImplOptions.AggressiveInlining)]
       public void Do(int i)
       {
          *(p + i) = 255;
       }
    }
    
    public static unsafe void Main()
    {
       int x = 10, y = 10, z = 1;
       var data = new byte[x, y, z];
    
       fixed (byte* pbytes = data)
       {
    
          var op = new UnsafeOps(pbytes);
    
          Parallel.For(
             0,
             x*y ,
             new ParallelOptions() {  MaxDegreeOfParallelism = Environment.ProcessorCount },
             i => op.Do(i));
       }
    }
