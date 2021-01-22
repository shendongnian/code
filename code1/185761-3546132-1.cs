    public void Execute(Action<string> action)
    {
        action("Hello world");
    }
    ...
    Execute(x => Console.WriteLine(x));
