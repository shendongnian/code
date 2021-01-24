    var leaguePairs = new String[3, 2] { { "Bayern Munich", "Bundesliga" }, { "Real Madrid", "La Liga" }, { "FC Barcelona", "La Liga" } };
    var playerPairs = new String[4, 2] { { "Player-1", "Bundesliga" }, { "Player-2", "La Liga" }, { "Player-3", "La Liga" }, { "Player-4", "*" } };
    
    var lookup = Enumerable.Range(0, leaguePairs.GetLength(0))
                           .Select(row =>
                                         new {
                                                Key = leaguePairs[row, 1],
                                                Value = leaguePairs[row, 0]
                                             })
                           .ToLookup(x => x.Key, 
                                     x => x.Value);
    var teams = Enumerable.Range(0, leaguePairs.GetLength(0))
                          .Select(row => leaguePairs[row, 0])
                          .ToHashSet();
            
    var list = Enumerable.Range(0, playerPairs.GetLength(0))
                         .SelectMany(row =>  
                                     playerPairs[row, 1] == "*" 
                                     ? 
                                     teams.Select(team => 
                                           new { 
                                               Name = playerPairs[row, 0], 
                                               Team = team 
                                          })
                                          .ToList()
                                      : 
                                      lookup[playerPairs[row, 1]]
                                      .Select(team => 
                                         new { 
                                              Name = playerPairs[row, 0], 
                                              Team = team 
                                         })
                                       .ToList()
                          ).ToList();
