c#
    class Program
    {
        static async Task Main(string[] args)
        {
            var waitHandle = new AutoResetEvent(true);
            var result = Enumerable
                .Range(0, 3)
                .Select(async (int param) => {
                    waitHandle.WaitOne();
                    await TestMethod(param);
                    waitHandle.Set();
                }).ToArray();
            waitHandle.Set();
            Console.ReadKey();
        }
        private static async Task<int> TestMethod(int param)
        {
            Console.WriteLine($"{param} before");
            await Task.Delay(50);
            Console.WriteLine($"{param} after");
            return param;
        }
    }
