    class Program
    {
        static Task statusCheckingTask;
        static void Main(string[] args)
        {
            statusCheckingTask = CheckStatusTask(10);
            Console.ReadLine();
        }
        static async Task CheckStatusTask(int delayInSeconds)
        {
            while (true)
            {
                await CheckStatus();
                await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
            }
        }
        static async Task CheckStatus()
        {
            Console.WriteLine("Checking status...");
            await Task.FromResult(0);
        }
    }
