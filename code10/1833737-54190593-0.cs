    private static void outOfLives()
    {
        t.Change(Timeout.Infinite, Timeout.Infinite);
        Console.WriteLine("Game over! You typed " + correctWords + " words correctly!");
        ...
