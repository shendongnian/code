    public static void Main()
        {
    
            ThreadPool.QueueUserWorkItem(new WaitCallback(PooledProc));
            Console.WriteLine("Main thread");            
            Thread.Sleep(1000);
            Console.WriteLine("Done from Main thread");
            Console.ReadLine();
        }
    
        // This thread procedure performs the task.
        static void PooledProc(Object stateInfo)
        {         
            Console.WriteLine("Pooled Proc");
        }
