    public static int X;
    public static Timer timer;
    public static int ReturnInt()
    {
        X = X + 1;
        return X;
    }
    
    public static void TimerCallback(object o)
    {
        var y = ReturnInt();
        Console.WriteLine("Value:" + y);
        timer.Change(y * 1000, 0);
        GC.Collect();
    }
    
    public static void Main(string[] args)
    {
        timer = new Timer(TimerCallback, null, 0, 0);
        Console.ReadLine();
    }
