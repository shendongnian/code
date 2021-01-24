    public delegate void InputProcessor(string line);
    public static event InputProcessor InputEvent;
    
    InputEvent += (line) =>
    {
        if (line == "hello")
            Console.WriteLine("world");
    };
    
    while (true)
    {
        var line = Console.In.ReadLine();
        InputEvent?.Invoke(line);
    }
