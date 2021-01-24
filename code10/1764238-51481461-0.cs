    double parsedNumber;
	for (int i = 0; i < numberArray.Length; i++)
	{
		bool numberIsValid = double.TryParse(numberArray[i], out parsedNumber);
		
		if (numberIsValid)
			test[i] = parsedNumber;	
		else
			Console.WriteLine($"{numberArray[i]} is not a valid double.");
	}
