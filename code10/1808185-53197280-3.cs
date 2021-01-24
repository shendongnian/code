    foreach (var game in gameArray)
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                game.BingoCard[row, col] = (byte)r.Next();
            }
        }
    }
