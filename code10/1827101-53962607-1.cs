    int players = int.Parse(Console.ReadLine());
    List<Player> activePlayers = new List<Player>();
    for(int i = 0; i <= players; i++)
    {
        activePlayers.Add(new Player((int[5, 3]), "Player " + i));
    } 
