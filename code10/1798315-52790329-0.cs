    static void Main(string[] args)
    {
        Game game = new Game();
        bool answer = game.CheckAnswer(); // now you are only asking for input once
        if(answer) Console.WriteLine("true");
        else Console.WriteLine("false");
    }   
