    public static void Main()
    {
        IOutputWriter consoleOut = new ConsoleWriter();
        WriteHelloWorldToOutput(consoleOut);
    }
    
    public static void WriteHelloWorldToOutput(IOutputWriter output)
    {
        output.WriteLine("Hello World");
    }
