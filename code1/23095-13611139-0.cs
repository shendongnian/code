    using System.Threading;
    new Thread(() => 
    {
        Thread.CurrentThread.IsBackground = true; 
        /* run your code here */ 
        Console.WriteLine("Hello, world"); 
    }).Start();
