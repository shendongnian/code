    GetInternetIdleTime(); //preemptive call
    Thread.Sleep(1000);
    var result = GetInternetIdleTime();
    if (result.HasValue)
    {
        Console.WriteLine("Idle time: {0}", result.Value);
    }
    else
    {
        Console.WriteLine("Not Idle");
    }
    Console.ReadKey();
