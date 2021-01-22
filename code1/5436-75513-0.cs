        public delegate void AsyncMethodCaller();
        public static void WorkerMethod()
        {
            Console.WriteLine("I am the first method that is called.");
            Thread.Sleep(5000);
            Console.WriteLine("Exiting from WorkerMethod.");
        }
        public static void SomeOtherMethod(IAsyncResult result)
        {
            Console.WriteLine("I am called after the Worker Method completes.");
        }
            
        static void Main(string[] args)
        {
            AsyncMethodCaller asyncCaller = new AsyncMethodCaller(WorkerMethod);
            AsyncCallback callBack = new AsyncCallback(SomeOtherMethod);
            IAsyncResult result = asyncCaller.BeginInvoke(callBack, null);
            Console.WriteLine("Worker method has been called.");
            Console.WriteLine("Waiting for all invocations to complete.");
            Console.Read();
        }
    }
