    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting SynchronizationContext");
            Nito.AsyncEx.AsyncContext.Run(Run);
            Console.WriteLine("SynchronizationContext finished");
        }
    
        // This method is run like it is a UI callback. I.e., it has a
        // single-threaded event-loop-based synchronization context which
        // processes asynchronous callbacks.
        static Task Run()
        {
            var remainingTasks = new Queue<Action>();
            Action startNextTask = () =>
            {
                if (remainingTasks.Any())
                    remainingTasks.Dequeue()();
            };
    
            foreach (var i in Enumerable.Range(0, 4))
            {
                remainingTasks.Enqueue(
                    () =>
                    {
                        var demoOperation = new AsyncDemoUsingAsyncOperations();
                        demoOperation.Started += (sender, e) => Console.WriteLine("Started");
                        demoOperation.NewNumber += (sender, e) => Console.WriteLine($"Received number {e.Num}");
                        demoOperation.Stopped += (sender, e) =>
                        {
                            // The AsyncDemoUsingAsyncOperation has a bug where it fails to call
                            // AsyncOperation.OperationCompleted(). Do that for it. If we don’t,
                            // the AsyncContext will never exit because there are outstanding unfinished
                            // asynchronous operations.
                            ((AsyncOperation)typeof(AsyncDemoUsingAsyncOperations).GetField("asyncOp", BindingFlags.NonPublic|BindingFlags.Instance).GetValue(demoOperation)).OperationCompleted();
    
                            Console.WriteLine("Stopped");
                            
                            // Start the next task.
                            startNextTask();
                        };
                        demoOperation.Start();
                    });
            }
    
            // Start the first one.
            startNextTask();
    
            // AsyncContext requires us to return a Task because that is its
            // normal use case.
            return Nito.AsyncEx.TaskConstants.Completed;
        }
    }
