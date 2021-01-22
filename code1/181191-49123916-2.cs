    public static void Main(string[] args)
    {
        object obj = "String Sample";
        ConsoleWrite(obj);// compile error
        ConsoleWrite((string)obj); // correct
        Console.ReadKey();
    }
