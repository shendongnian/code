	public static string Ask(string question)
	{
		string input;
		do
		{
			Console.Write(question);
            //Assigns the user input to the 'input' variable
			input = Console.ReadLine();
		} //Checks if any character is NOT a letter 
        while (input.Any(x => !char.IsLetter(x)));
        //If we are here then 'input' has to be all letters
		return input;
	}
