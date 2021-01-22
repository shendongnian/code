    static AutoResetEvent autoEvent = new AutoResetEvent(true);
    if(autoEvent.WaitOne(0))
    {
        //start critical section
        Console.WriteLine("no other thread here, do your job");
        Thread.Sleep(5000);
        //end critical section
        autoEvent.Set();
    }
    else
    {
        Console.WriteLine("A thread working already at this time.");
    }
