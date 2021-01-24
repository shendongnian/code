    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Console.WriteLine("The application has started");
                AsyncContext.Run(() => LongRunningTaskAsync(args));
                Console.WriteLine("The application has finished");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return -1;
            }
        }
        static async Task LongRunningTaskAsync(string[] args)
        {
            Console.WriteLine("The long running task has started");
            // use Task.Delay() rather than Thread.Sleep() to avoid blocking the application
            await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
            Console.WriteLine("The long running task has finished");  
        }
    }
