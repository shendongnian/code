    static void Main(string[] args)
    {
        var player = new Player();
        Console.Write("Enter Name : ");
        var name = Console.ReadLine();
        player.Name = name;
        Console.WriteLine("First of all select your color!");
        Console.WriteLine("Type 1 for Blue");
        Console.WriteLine("Type 2 for Green");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.KeyChar == '1')
        {
            player.Color = ConsoleColor.Blue;
        }
        if (keyInfo.KeyChar == '2')
        {
            player.Color = ConsoleColor.Green;
        }
        player.Speak(string.Format("You have chosen {0}", player.Color.ToString()));
        Console.ReadLine();
    }
