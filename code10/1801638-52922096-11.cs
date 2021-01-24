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
                //Because I am NOT async I will run all logic in the newly executed Task
                return Task.Run(() =>
                {
                    Console.WriteLine($"{nameof(DoWorkAsync)} starting: {GetTaskName()}");
                    Task.Delay(1000).Wait();
                    //Since I didn't follow an await I am executed in the same Task as my brethren :)  Nice!
                    Console.WriteLine($"{nameof(DoWorkAsync)} ending: {GetTaskName()}");
                });
            }
        }
        //Before Task: Main Task
        //DoWorkAsync starting: Task Id 1
        //DoWorkAsync ending: Task Id 1
        //After Task: Main Task
    }
