    using System;
    using System.Diagnostics;
    
    public static class Test
    {    
        const int Iterations = 100000;
        
        static void Main(string[] args)
        {
            Measure(ByteLoop);
            Measure(ShortLoop);
            Measure(IntLoop);
            Measure(BackToBack);
            Measure(DelegateOverhead);
        }
        
        static void Measure(Action action)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine("{0}: {1}ms", action.Method.Name,
                              sw.ElapsedMilliseconds);
        }
        
        static void ByteLoop()
        {
            for (byte index = 0; index < 127; index++)
            {
                index.ToString();
            }
        }
    
        static void ShortLoop()
        {
            for (short index = 0; index < 127; index++)
            {
                index.ToString();
            }
        }
    
        static void IntLoop()
        {
            for (int index = 0; index < 127; index++)
            {
                index.ToString();
            }
        }
        
        static void BackToBack()
        {
            for (byte index = 0; index < 127; index++)
            {
                index.ToString();
            }
            for (short index = 0; index < 127; index++)
            {
                index.ToString();
            }
            for (int index = 0; index < 127; index++)
            {
                index.ToString();
            }
        }
        
        static void DelegateOverhead()
        {
            // Nothing. Let's see how much
            // overhead there is just for calling
            // this repeatedly...
        }
    }
