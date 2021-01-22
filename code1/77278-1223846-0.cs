    using System;
    using System.Diagnostics;
    
    namespace YCombinator
    {
        class Program
        {
            static Func<T, U> y<T, U>(Func<Func<T, U>, Func<T, U>> f)
            {
                return f(x => y<T, U>(f)(x));
            }
    
            static int fibIter(int n)
            {
                int fib0 = 0, fib1 = 1;
                for (int i = 1; i <= n; i++)
                {
                    int tmp = fib0;
                    fib0 = fib1;
                    fib1 = tmp + fib1;
                }
                return fib0;
            }
    
            static Func<int, int> fibCombinator()
            {
                return y<int, int>(f => n =>
                {
                    switch (n)
                    {
                        case 0: return 0;
                        case 1: return 1;
                        default: return f(n - 1) + f(n - 2);
                    }
                });
            }
    
            static int fibRecursive(int n)
            {
                switch (n)
                {
                    case 0: return 0;
                    case 1: return 1;
                    default: return fibRecursive(n - 1) + fibRecursive(n - 2);
                }
            }
    
            static void Benchmark(string msg, int iterations, Func<int, int> f)
            {
                int[] testCases = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20 };
                Stopwatch watch = Stopwatch.StartNew();
                for (int i = 0; i <= iterations; i++)
                {
                    foreach (int n in testCases)
                    {
                        f(n);
                    }
                }
                watch.Stop();
                Console.WriteLine("{0}: {1}", msg, watch.Elapsed.TotalMilliseconds);
            }
    
            static void Main(string[] args)
            {
                int iterations = 10000;
                Benchmark("fibIter", iterations, fibIter);
                Benchmark("fibCombinator", iterations, fibCombinator());
                Benchmark("fibRecursive", iterations, fibRecursive);
                Console.ReadKey(true);
            }
        }
    }
