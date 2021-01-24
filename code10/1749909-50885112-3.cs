    string input;
    int[] arr;
    do
	{
		input = Console.ReadLine();
		
		if (string.IsNullOrWhiteSpace(input))
		{
			Console.WriteLine($"Good bye!");
			return;
		}
	} while (!TryParseIntegerArray(input, out arr));   
