    internal class Program
    {
        private static void Main(string[] args)
        {
            // REMEMBER TO RUN IN RELEASE MODE
            var handler = new EventHandler<UnobservedTaskExceptionEventArgs>(Unobserved);
            TaskScheduler.UnobservedTaskException += handler;
            Task.Run(() => { Console.WriteLine("task 1"); throw new Exception("TASK 1 EXCEPTION"); });
            Task.Run(() => { Console.WriteLine("task 2"); throw new Exception("TASK 2 EXCEPTION"); });
            Thread.Sleep(1000);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Thread.Sleep(1000);
            Console.ReadKey();
        }
        private static void Unobserved(object o, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved(); // optional
            foreach (var ex in e.Exception.InnerExceptions)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
