	void Main()
	{
		const int count = 10;
		const int max = 25;
	
		//an array named "input" to hold the users' 10 guesses
		int[] inputs = new int[count];
	
		//a for loop to loop over the inputs array. each loop will ask the user for a number
		Console.WriteLine("Enter your {0} lottery numbers one at a time. The numbers must be between 1 and {1}.", count, max);
		for (int i = 0; i < inputs.Length; i++)
		{
			inputs[i] = Convert.ToInt32(Console.ReadLine());
		}
	
		//a random number generator  
		Random ranNum = new Random();
	
		//an array named "allNums" to hold all the random numbers
		int[] allNums = new int[max];
		for (int i = 0; i < allNums.Length; i++)
		{
			allNums[i] = i + 1;
		}
	
		//shuffle
		for (int i = 0; i < allNums.Length; i++)
		{
			int j = ranNum.Next(0, allNums.Length);
			int temporary = allNums[j];
			allNums[j] = allNums[i];
			allNums[i] = temporary;
		}
	
		//an array named "lotNum" to hold 10 random numbers
		int[] lotNums = new int[count];
	
		Array.Copy(allNums, lotNums, lotNums.Length);
	
		//writes out the randomly generated lotto numbers
		Console.Write("\nThe lottery numbers are: ");
		for (int i = 0; i < lotNums.Length; i++)
		{
			Console.Write("{0}  ", lotNums[i]);
		}
	
		int correct = 0;
		Console.Write("\nThe correct numbers are: ");
		for (int i = 0; i < lotNums.Length; i++)
		{
			for (int j = 0; j < inputs.Length; j++)
			{
				if (lotNums[i] == inputs[j])
				{
					Console.Write("{0}  ", lotNums[i]);
					correct++;
				};
			}
		}
	
		Console.Write("\nYou got {0} correct. ", correct);
	
		Console.WriteLine("\n\nPress any key to end the program:");
		Console.ReadLine();
	}
	
