    public int CheatEatenApples(int startingApples, int newEvery)
    {
    	var firstGuess = (double)startingApples*newEvery/(newEvery-1);
    	
    	if (firstGuess%1==0) // Checks if firstGuess is a whole number
    	{
    		return (int)firstGuess-1;
    	}
    	else
    	{
    		return (int)firstGuess;
    	}
    }
