    static void Main()
    {
        object obj = new object();
        Console.WriteLine("Main thread wants the lock");
        lock (obj)
        {
            Console.WriteLine("Main thread has the lock...");
            ThreadPool.QueueUserWorkItem(ThreadMethod, obj);
            Thread.Sleep(1000);
            Console.WriteLine("Main thread about to wait...");
            Monitor.Wait(obj); // this releases and re-acquires the lock
            Console.WriteLine("Main thread woke up");
        }
        Console.WriteLine("Main thread has released the lock");
    }
    static void ThreadMethod(object obj)
    {
        Console.WriteLine("Pool thread wants the lock");
        lock (obj)
        {
            Console.WriteLine("Pool thread has the lock");
            Console.WriteLine("(press return)");
            Console.ReadLine();
            Monitor.PulseAll(obj); // this signals, but doesn't release the lock
            Console.WriteLine("Pool thread has pulsed");
        }
        Console.WriteLine("Pool thread has released the lock");
    }
    
