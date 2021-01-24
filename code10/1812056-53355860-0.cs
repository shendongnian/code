    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp2
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");
    
                Task.Run(async () => await Bar());
    //            Task.Run(() => Bar());
    //            Bar();
    
                Console.ReadLine();
            }
    
            static async Task Bar()
            {
                Console.WriteLine($"Bar thread before await: {Thread.CurrentThread.ManagedThreadId}");
                await Foo();
                Console.WriteLine($"Bar thread after await: {Thread.CurrentThread.ManagedThreadId}");
            }
    
            static async Task Foo()
            {
                Console.WriteLine($"Foo thread before await: {Thread.CurrentThread.ManagedThreadId}");
    
                var c = new WebClient();
                var source = await c.DownloadStringTaskAsync("http://google.com");
    
                Console.WriteLine($"Foo thread after await: {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
