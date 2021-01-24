    public static extern int TestFunction();
    public static extern int CleanUp();
    static void Main(string[] args)
    {
        Console.WriteLine("!!" + TestFunction());
        CleanUp();
    }
