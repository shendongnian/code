    public Int x = 0;
    public static void Main(string[] args)
    {
        Timer t = new Timer(TimerCallback, x, 0, x * 1000);
        Console.ReadLine();
    }
