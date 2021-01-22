    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            PostRequest();
        }
    }
    private static void PostRequest()
    {
        Console.Write("Start...");
     
    Retry:
        try
        {
            CodeThatMightThrowAnException();
            Console.WriteLine("Done!");
        }
        catch (ConnectionClosedException e)
        {
            Console.Write("Error! Attempt to reconnect...");
            goto Retry;
        }
    }
    
    static Random _randomizer = new Random();
    private static void CodeThatMightThrowAnException()
    {   var randomEvent = _randomizer.Next(20);
        Console.Write("- {0} -", randomEvent);
        if ( randomEvent % 3 == 0)
            throw new ConnectionClosedException("Server dropped me!");
    }
