    private static void MyLog(string format, params object[] list) 
    {
        Console.WriteLine(format, list);
    }
    private static void MyLog(StreamWriter log, string format, params object[] list) 
    {
        log.WriteLine(format, list);
    }
