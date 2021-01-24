    Queue<Player> playerQueue = new Queue<Player>();
    int number_of_players = 4;
    /// <summary>
    ///  Adds new player to Queue
    /// </summary> 
    for (int i = 0; i < number_of_players; i++)
    {
        Player player = new Player();
        playerQueue.Enqueue(player);
    }
    /// <summary>
    ///  Get the first player in the playerQueue
    /// </summary>  
    // HERE IS THE SOLUTION
    while(playerQueue.Any())
    { 
         System.Console.WriteLine(playerQueue.Count());
         System.Console.WriteLine(i);
         // Get the first player in the playerQueue 
         Player PlayerInGame = playerQueue.Dequeue();
        // Play the game with the current player in the queue
    }
