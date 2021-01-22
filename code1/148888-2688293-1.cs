    public static void Main()
    {   
        Console.WriteLine("Main thread starting.");
        String[] strThreads = new String[] { "one", "two" };
        int threadCount = strThreads.Length;
        AutoResetEvent eventdone = new AutoResetEvent(false);
 
        String ctemp = string.Empty;
        foreach (String c in strThreads)
        {
            ctemp = c;
            Thread thread = new Thread(delegate() { 
                try
                {
                   MethodCall(ctemp); 
                }
                finally 
                {
                   if (0 == Interlocked.Decrement(ref threadCount) 
                   {
                      eventDone.Set();
                   }
                }
            });
            thread.Start();
        }
        eventDone.WaitOne();
        Console.WriteLine("Main thread ending.");
        Console.Read();
    }
    public static void MethodCalls(string number)
    {
        Console.WriteLine("Method call " + number);
    }
