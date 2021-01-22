    using System;
    using System.Diagnostics;
    static class Program {
        static void Main() { 
            // JIT
            TestUnrestricted<int>(1,5);
            TestUnrestricted<string>("abc",5);
            TestUnrestricted<int?>(1,5);
            TestNullable<int>(1, 5);
    
            const int LOOP = 100000000;
            Console.WriteLine(TestUnrestricted<int>(1, LOOP));
            Console.WriteLine(TestUnrestricted<string>("abc", LOOP));
            Console.WriteLine(TestUnrestricted<int?>(1, LOOP));
            Console.WriteLine(TestNullable<int>(1, LOOP));
            
        }
        static long TestUnrestricted<T>(T x, int loop) {
            Stopwatch watch = Stopwatch.StartNew();
            int count = 0;
            for (int i = 0; i < loop; i++) {
                if (x != null) count++;
            }
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        static long TestNullable<T>(T? x, int loop) where T : struct {
            Stopwatch watch = Stopwatch.StartNew();
            int count = 0;
            for (int i = 0; i < loop; i++) {
                if (x != null) count++;
            }
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
