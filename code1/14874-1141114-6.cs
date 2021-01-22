    long now = DateTime.Now.Ticks;
    for (int i = 0; i < 10; i++)
    {
        System.Threading.Thread.Sleep(1);
        Console.WriteLine(DateTime.Now.Ticks - now);
    }
