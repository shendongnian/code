    class Program
    {
        static Task<TOut> ThreadWithCustomStack<TIn, TOut>(Func<TIn, TOut> action, TIn arg, int stackSize)
        {
            var tcs = new TaskCompletionSource<TOut>();
            var thread = new Thread(new ThreadStart(() => 
            {
                try
                {
                    tcs.SetResult(action(arg));
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
            var result = await ThreadWithCustomStack(
                arg => { Console.WriteLine("Task"); return arg.ToString(); }, 
                2, 
                0xffff * 2);
        }
        static void Main(string[] args)
        {
            Test().Wait();
        }
    }
