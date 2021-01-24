    static void Main(string[] args)
    {
        InvokeIfNotNullOrWhitespace((inputStr) => TestMethod(inputStr), null);
        InvokeIfNotNullOrWhitespace((inputStr) => TestMethod(inputStr), "");
        InvokeIfNotNullOrWhitespace((inputStr) => TestMethod(inputStr), "abc");
        // RESULT:
        // Trying to invoke action...
        // Trying to invoke action...
        // Trying to invoke action...
        // I have been invoked!
    }
    static void InvokeIfNotNullOrWhitespace(Action<string> action, string inputString)
    {
        Console.WriteLine("Trying to invoke action...");
        if(!string.IsNullOrWhiteSpace(inputString))
            action.DynamicInvoke(inputString);
    }
    static void TestMethod(string input)
    {
        Console.WriteLine("I have been invoked!");
    }
