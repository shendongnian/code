    using System;
    using System.Threading;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Start Main");
    
                Thread thread = null;
                thread = new Thread(new ThreadStart(() =>
                {
                    Console.WriteLine("Thread Started");
                    using (var r = new R(thread))
                    {
                        Console.WriteLine($"Using {nameof(R)}");
                    }
                }));
    
                thread.Start();
                thread.Join();
    
                Console.WriteLine("End Main");
                Console.ReadKey();
            }
        }
    
        public class R : IDisposable
        {
            public R(Thread thread)
            {
                Console.WriteLine($"Init {nameof(R)}");
                //thread.Abort();
            }
    
            public void Dispose()
            {
                Console.WriteLine($"Disposed {nameof(R)}");
            }
        }
    }
