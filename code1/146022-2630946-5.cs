    public static void Main(string[] args) {
        Foo.DoSomethingAsynchronous(WriteResultToConsole);
    }
    // Here's your SimpleCallback
    public static WriteResultToConsole(bool result) {
        Console.WriteLine(result? "Success!" : "Failed!");
    }
