    static Barrier barrier = new Barrier(2, (bar) =>
    {
      Console.WriteLine($"Current sprint number: {bar.CurrentPhaseNumber}.");
    });
    
    public static void task1() 
    {
        Console.WriteLine("Start of sprint 1 (task1)");
        barrier.SignalAndWait(); //Need to wait for task2 to complete sprint1 and proceed.
        Console.WriteLine("End of sprint 1 (task1)");
        Console.WriteLine("Start of sprint 2 (task1)");
        barrier.SignalAndWait(); //Need to wait for task2 to complete sprint2 and proceed.
        Console.WriteLine("End of sprint 2 (task1)");
    }
    public static void task2()
    {
        Console.WriteLine("Start of sprint 1 (task2)");
        Thread.Sleep(2000);
        barrier.SignalAndWait();
        Console.WriteLine("End of sprint 1 (task2)");
        Console.WriteLine("Start of sprint 2 (task2)");
        Thread.Sleep(2000);
        barrier.SignalAndWait();
        Console.WriteLine("End of sprint 2 (task2)");   
    }
