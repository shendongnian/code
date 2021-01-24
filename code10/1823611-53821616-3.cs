    Random r = new Random();
    
    int[] dice = new int[2];
    dice[0] = r.Next(1,6);
    dice[1] = r.Next(1,6);
    movePlayertoNewSquare(dice);
    private void movePlayerToNewSquare(int[] diceroll)
    {
        p.currentGameSquare += diceroll.Sum();
        //You would need logic to determine if the player passed go and account for that
        p.Location = gameBoard.Where(x => x.id == p.currentGameSquare).Single().Location);
    }
