    int numberOfPlayers = Int32.Parse(Console.ReadLine());
    //List which will contain each Player object
    List<Player> players = new List<Player>();
    for(int i = 0; i <= numberOfPlayers; i++)
    {
        //Just instantiate a new Player object
        Player player = new Player(new int[5, 3], "Player " + i);
        //Add the Player to the List
        players.Add(player);
    } 
