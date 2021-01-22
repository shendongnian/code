    List<Game> AllGamesInSchedule = new List<Game>();
    
    for (int i = 1; i <= 10; i++) {
        for (int j = (i + 1); j <= 10; j++) {
            AllGamesInSchedule.Add(new Game(i, j));
        }
    }
    
    // This prints all the different game combinations out to the console to see
    // that they are all different.
    foreach (Game game in AllGamesInSchedule) {
        Console.WriteLine(game.ToString());
    }
