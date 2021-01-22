    class Program {
        static void Main(string[] args) {
            TaskScheduler.UnobservedTaskException += ( object sender, UnobservedTaskExceptionEventArgs eventArgs ) =>
            {
                eventArgs.SetObserved();
                ( (AggregateException)eventArgs.Exception ).Handle( ex =>
                {
                    Console.WriteLine("Exception type: {0}", ex.GetType());
                    return true;
                } );
            };
            Run();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("done");
            Console.ReadLine();
        }
        static void Run() {
            Task task1 = new Task(() => {
                throw new ArgumentNullException();
            });
            Task task2 = new Task(() => {
                throw new ArgumentOutOfRangeException();
            });
            task1.Start();
            task2.Start();
            while (!task1.IsCompleted || !task2.IsCompleted) {
                Thread.Sleep(50);
            }
        }
    }
