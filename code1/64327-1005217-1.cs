    GuessingGame game = new GuessingGame();
    
    private void btnPlay_Click(object sender, EventArgs e)
    {
        int numberOfGuesses = Convert.ToInt32(txtNumberOfGuesses.Text);
        int max = Convert.ToInt32(txtMax.Text);
    	game.StartNewGame(numberOfGuesses, max);
    }
    private void btnGuess_Click(object sender, EventArgs e)
    {
        int guess = Convert.ToInt32(txtGuess.Text);
        bool correct = game.MakeGuess(guess);
        
        if (correct) 
            lblWin.Visible = true;
        
        if (game.GameEnded)
        {
            // disable guess button, show loss label
        }
    }
