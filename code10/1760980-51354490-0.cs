	int value;
    protected void Page_Load(object sender, EventArgs e)
    {
        Random rand = new Random();
        value = rand.Next(0, 10);
		
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        int numGuess = 0;
        int guess = Convert.ToInt32(txtGuess.Text);
			do{
				if (guess > value)
				{
					numGuess++;
					lblResult.Text = "Guess is too high, try again. ";
					lblGuess.Text = "The number of guesses is " + numGuess;
				}
				else if (guess < value)
				{
					numGuess++;
					lblResult.Text = "Guess is too low, try again. ";
					lblGuess.Text = "The number of guesses is " + numGuess;
				}
				else if (guess == value)
				{
					numGuess++;
					lblResult.Text = "You win! Good job. ";
					lblGuess.Text = "The number of guesses is " + numGuess;
				}
			
			}while(numGuess < 3)
				
			Page_Load();
    }
}
