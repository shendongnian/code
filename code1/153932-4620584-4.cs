    // TEST 1
    
    for (int i = 0; i < 999999; i++)
    {
      KeyValuePair<GameMove, int> bestMove1 = possibleMoves.First();
      foreach (KeyValuePair<GameMove, int> move in possibleMoves)
      {
        if (move.Value > bestMove1.Value) bestMove1 = move;
      }
    }
    
    // TEST 2
    
    for (int i = 0; i < 999999; i++)
    {
      KeyValuePair<GameMove, int> bestMove2 = possibleMoves.Aggregate((a, b) => a.Value > b.Value ? a : b);
    }
    
    // TEST 3
    
    for (int i = 0; i < 999999; i++)
    {
      KeyValuePair<GameMove, int> bestMove3 = (from move in possibleMoves orderby move.Value descending select move).First();
    }
    
    // TEST 4
    
    for (int i = 0; i < 999999; i++)
    {
      KeyValuePair<GameMove, int> bestMove4 = possibleMoves.OrderByDescending(entry => entry.Value).First();
    }
