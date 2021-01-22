    IAsyncResult a = d.BeginInvoke(null, null); //I have removed callback
    for (int j = 0; j < 100; j++)
    {
        Console.Write("JJJ");
        Thread.Sleep(1);
    }    
    int returned=d.EndInvoke(a);
    Console.WriteLine("AAA");
