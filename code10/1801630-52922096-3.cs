    using System;
    using System.Threading.Tasks;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test();
                Console.ReadKey();
            }
    
            public static void Test()
            {
                Console.WriteLine($"Before Task");
                var task = DoWorkAsync();
                var taskAwaiter = task.GetAwaiter();
                taskAwaiter.OnCompleted(() => Console.WriteLine($"After Task"));
            }
    
            static public Task DoWorkAsync()
            {
                return Task.Run(() =>
                {
                    Console.WriteLine($"{nameof(DoWorkAsync)} starting...");
                    Task.Delay(1000).Wait();
                    Console.WriteLine($"{nameof(DoWorkAsync)} ending...");
                });
            }
        }
    }
    //OUTPUT
    //Before Task
    //DoWorkAsync starting...
    //DoWorkAsync ending...
    //After Task
