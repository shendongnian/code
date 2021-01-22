    public static void Main(string[] args) {
        Foo.DoSomethingAsynchronous(WriteResultToConsole);
    }
    // Here's your SimpleCallback
    public static WriteResultToConsole(bool succeeded) {
        Console.WriteLine(succeeded ? "Success!" : "Failed!");
    }
