    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace HelloConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProfileMethod(() => SomeLongRunningMethod(), nameof(SomeLongRunningMethod));
                var result = ProfileFunction(() => SomeLongRunningFunction(), nameof(SomeLongRunningFunction));
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
    
            public static void ProfileMethod(Action action, string methodName)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                action();
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed ({stopwatch.Elapsed}): {methodName}");
            }
    
            public static T ProfileFunction<T>(Func<T> function, string functionName)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var result = function();
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed ({stopwatch.Elapsed}): {functionName}");
                return result;
            }
    
            public static void SomeLongRunningMethod()
            {
                Thread.Sleep(1000);
            }
    
            public static double SomeLongRunningFunction()
            {
                Thread.Sleep(1000);
                return 3.14;
            }
        }
    }
