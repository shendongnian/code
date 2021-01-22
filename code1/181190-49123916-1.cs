    public static void Main(string[] args)
    {
        dynamic dyn = "String Sample";
        ConsoleWrite(dyn);
        dyn = 1;
        ConsoleWrite(dyn);// Runtime Error
        Console.ReadKey();
    }
