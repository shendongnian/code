    public class GameGroup
    {
      public DateTime TheDate {get;set;}
      public List<Game> TheGames {get;set;}
    }
//
    
    public List<GameGroup> getGamesGroups(int leagueID)
    {
      List<GameGroup> sortedGameList =
        Games
        .GroupBy(game => game.Date)
        .OrderBy(g => g.Key)
        .Select(g => new GameGroup(){TheDate = g.Key, TheGames = g.ToList})
        .ToList();
    
      return sortedGameList;
    }
