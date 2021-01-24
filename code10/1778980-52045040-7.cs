    static void Main(string[] args)
    {
        var player1 = new Player();
        player1.GetPlayerInfo();
        player1.Speak(string.Format("You have chosen {0}", player1.Color.ToString()));
        var player2 = new Player();
        player2.GetPlayerInfo();
        player2.Speak(string.Format("You have chosen {0}", player2.Color.ToString()));
        Console.ReadLine();
    }
