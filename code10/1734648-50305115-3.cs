    public static event EventHandler<string> InputEvent;
    public void Run() 
    {
        InputEvent += (sender, line) =>  {
            if (line == "hello")
                Console.WriteLine("world");
        };
    
        while (true) {
            var line = Console.In.ReadLine();
            InputEvent?.Invoke(this, line);
        }
    }
