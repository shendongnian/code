    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    
    struct BigStruct
    {
        public Guid guid1, guid2, guid3, guid4;
        public decimal dec1, dec2, dec3, dec4;
    }
    
    class Test
    {
        const int Iterations = 100000000;
     
        static void Main()
        {
            decimal total = 0m;
            // JIT first
            ReturnValue();
            BigStruct tmp;
            OutParameter(out tmp);
    
            Stopwatch sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                BigStruct bs = ReturnValue();
                total += bs.dec1;
            }
            sw.Stop();
            Console.WriteLine("Using return value: {0}",
                              sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                BigStruct bs;
                OutParameter(out bs);
                total += bs.dec1;
            }
            Console.WriteLine("Using out parameter: {0}",
                              sw.ElapsedMilliseconds);
        }
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BigStruct ReturnValue()
        {
            return new BigStruct();
        }
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void OutParameter(out BigStruct x)
        {
            x = new BigStruct();
        }
    }
