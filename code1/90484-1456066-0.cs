    PerformanceCounter myCounter = 
        new PerformanceCounter(counterCategory, counterName, false);
    
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("Setting to "+i);
        myCounter.Increment();
        Thread.Sleep(200);
    }
    
    myCounter.Close();
