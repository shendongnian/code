    class Program
    {
        static Task ThreadWithCustomStack(Action action, int stackSize)
        {
            var tcs = new TaskCompletionSource<bool>();
            var thread = new Thread(new ThreadStart(() => 
            {
                try
                {
                    action();
                    tcs.SetResult(true);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            }), stackSize);
            thread.Start();
            thread.Join();
            return tcs.Task;
        }
        async static Task Test()
        {
            await ThreadWithCustomStack(() => { Console.WriteLine("Task"); }, 0xffff * 2);
        }
        static void Main(string[] args)
        {
            Test().Wait();
        }
    }
