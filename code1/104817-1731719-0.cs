    int input;
    bool validInput = false;
    
    while (!validInput)
    {
    	validInput = int.TryParse(Console.ReadLine(), out input);
    	if (!validInput || input < 0 && input > 20)
    	{
    		validInput = false; // We need to set this again to false if the input is not between 0 & 20!
    		Console.WriteLine("Please enter a number between 0 and 20");
    	}
    }
