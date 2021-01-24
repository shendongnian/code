    int players = int.Parse(Console.ReadLine());
    List<Player> ActivePlayers = new List<Player>();
    for(int i = 0; i <= players; i++)
    {
        ActivePlayers.Add(new Player((int[5, 3]), "Player " + i));
    } 
