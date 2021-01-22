    new System.Threading.Thread(() => 
    {
        System.Threading.Thread.CurrentThread.IsBackground = true; 
        /* run your code here */ 
        Console.WriteLine("Hello, world"); 
    }).Start();
