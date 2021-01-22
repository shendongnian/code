    [Conditional("DEBUG")]
    void PrintLog() {
        Console.WriteLine("Debug info");
    }
    void Test() {
        PrintLog();
    }
