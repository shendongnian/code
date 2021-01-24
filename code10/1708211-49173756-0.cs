    class Program
        {
            static void Main(string[] args)
            {
                Test test1 = new Test();
                Task Scan1 = Task.Run(() => test1.Run("1"));
                
    
                Test test2 = new Test();
                Task Scan2 = Task.Run(() => test2.Run("2"));
    
                while(!Scan1.IsCompleted || !Scan2.IsCompleted)
                {
                    Thread.Sleep(1000);
                }
    
            }
        }
    
        public class Test
        {
            private object _queueLock = new object();
            public async Task Run(string val)
            {
                lock (_queueLock)
                {
                    Console.WriteLine($"{val} locked");
                    Thread.Sleep(10000);
                    Console.WriteLine($"{val} unlocked");
                }
            }
        }
