    int players = int.Parse(Console.ReadLine());
    //List which will contain each Player object
    List<Player> playrs = new List<Player>();
    for(int i = 0; i <= players; i++)
    {
        //Just instantiate a new Player object
        Player player = new Player((int[5, 3]), "Player " + i);
        //Add the Player to the List
        playrs.Add(player);
    } 
