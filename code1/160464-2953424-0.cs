    public delegate void Del(string message);
    // Create a method for a delegate.
    public static void DelegateMethod(string message)
    {
        System.Console.WriteLine(message);
    }
    // Instantiate the delegate.
    Del handler = DelegateMethod;
    
    // Call the delegate.
    handler("Hello World");
