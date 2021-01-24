    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Parallel.Invoke(test, test, test);
            }
            static void test()
            {
                if (_thisThreadAlreadyHere)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is already working.");
                    return;
                }
                _thisThreadAlreadyHere = true;
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is working.");
                Thread.Sleep(1000);
                test();
                Thread.Sleep(1000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has completed.");
                _thisThreadAlreadyHere = false;
            }
            [ThreadStatic]
            static bool _thisThreadAlreadyHere;
        }
    }
