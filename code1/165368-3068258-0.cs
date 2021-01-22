    public static void Write(string msg, params object[] args)
    {
        WriteTimeStamp();
        Console.WriteLine(msg, args);
    }
