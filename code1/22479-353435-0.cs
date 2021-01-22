    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    
    class Test
    {
        const int Iterations = 100000000;
        
        private static readonly Type TestType = typeof(Test);
        
        static void Main()
        {
            int total = 0;
            // Make sure it's JIT-compiled
            Log(typeof(Test)); 
            
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                total += Log(typeof(Test));
            }
            sw.Stop();
            Console.WriteLine("typeof(Test): {0}ms", sw.ElapsedMilliseconds);
            
            sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                total += Log(TestType);
            }
            sw.Stop();
            Console.WriteLine("TestType (field): {0}ms", sw.ElapsedMilliseconds);
            
            Test test = new Test();
            sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                total += Log(test.GetType());
            }
            sw.Stop();
            Console.WriteLine("test.GetType(): {0}ms", sw.ElapsedMilliseconds);
        }
        
        // I suspect your real Log method won't be inlined,
        // so let's mimic that here
        [MethodImpl(MethodImplOptions.NoInlining)]
        static int Log(Type type)
        {
            return 1;
        }
    }
