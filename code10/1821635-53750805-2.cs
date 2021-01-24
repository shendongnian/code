    private Result DetermineWinner(HandSign player, HandSign computer)
    {
        if (player == computer)
        {
            return Result.Draw;
        }
        if (player == HandSign.Scissors && computer == HandSign.Rock)
        {
            return Result.ComputerWins;
        }
        if (player == HandSign.Rock && computer == HandSign.Scissors)
        {
            return Result.PlayerWins;
        }
        if (player > computer)
        {
            return Result.PlayerWins;
        }
        //finally, otherwise
        return Result.ComputerWins;
    }
