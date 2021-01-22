    int c = 1000000;
    int s = Environment.TickCount;
    for (int i = 0; i < c; i++)
    {
        try { throw new Exception(); }
        catch { }
    }
    int d = Environment.TickCount - s;
    Console.WriteLine(d + "ms / " + c + " exceptions");
