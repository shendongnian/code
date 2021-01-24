    using System;
    using System.Threading;
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
    
            public static async void Test()
            {
                Console.WriteLine($"Before Task: {GetTaskName()}");
                var context = Thread.CurrentContext.ContextID;
                await DoWorkAsync();
                Console.WriteLine($"After Task: {GetTaskName()}");
            }
    
            private static string GetTaskName() => Task.CurrentId == null ? "Main Task" : $"Task Id {Task.CurrentId}";
    
            static public Task DoWorkAsync()
            {
                //Because I make the lambda async the caller will get the continuation!
                return Task.Run(async () =>
                {
                    Console.WriteLine($"{nameof(DoWorkAsync)} starting: {GetTaskName()}");
                    await Task.Delay(1000);
                    //Since I am after the await I am the continuation and given back to the caller!
                    Console.WriteLine($"{nameof(DoWorkAsync)} ending: {GetTaskName()}");
                });
            }
        }
        //Before Task: Main Task
        //DoWorkAsync starting: Task Id 1
        //DoWorkAsync ending: Main Task
        //After Task: Main Task
    }
