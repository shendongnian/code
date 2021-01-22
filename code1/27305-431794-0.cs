    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    
    public class Test
    {
        const int Iterations = 1000000000;
        
        static void Main()
        {
            Stopwatch sw;
            
            sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                SimpleMethod();
            }
            sw.Stop();
            Console.WriteLine("Simple method: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                NoInlining();
            }
            sw.Stop();
            Console.WriteLine("No inlining: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                TryCatchThrow();
            }
            sw.Stop();
            Console.WriteLine("try/catch/throw: {0}", sw.ElapsedMilliseconds);
        }
        
        static void SimpleMethod()
        {
            Foo();
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void NoInlining()
        {
        }
        
        static void TryCatchThrow()
        {
            try
            {
                Foo();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        static void Foo() {}
    }
