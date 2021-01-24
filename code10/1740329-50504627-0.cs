    using System;
    using System.Threading;
    using System.Threading.Tasks;                                                    
    namespace Demo
    {
        class Program
        {
            public static async Task Main()
            {
                Console.WriteLine("Awaiting DoWork()");
                await DoWork();
                Console.WriteLine("Finished awaiting. Press <RETURN> to exit.");
                Console.ReadLine();
            }
            public static async Task DoWork()
            {
                try
                {
                    await Task.WhenAll(
                        Task.Run(() => Foo()),
                        Task.Run(() => Foo2()),
                        Task.Run(() => Foo3())
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine("Caught exception: " + e.Message);
                }
            }
            public static void Foo()
            {
                Console.WriteLine("Starting Foo()");
                Thread.Sleep(1000);
                Console.WriteLine("Finishing Foo()");
            }
            public static void Foo2()
            {
                Console.WriteLine("Starting Foo2()");
                Thread.Sleep(500);
                Console.WriteLine("Foo2() is throwing an exception.");
                throw new InvalidOperationException("OOPS!");
            }
            public static void Foo3()
            {
                Console.WriteLine("Starting Foo3()");
                Thread.Sleep(250);
                Console.WriteLine("Finishing Foo3()");
            }
        }
    }
                                                                
