    public void GetMessages() 
    {
        using (IBus bus = RabbitHutch.CreateBus(Host))
        {
            bus.Subscribe<TextMessage>(Guid.NewGuid().ToString(), HandleTextMessage);
            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();
        }
    }
    static void HandleTextMessage(TextMessage textMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Got message: {0}", textMessage.Text);
        Console.ResetColor();
    }
