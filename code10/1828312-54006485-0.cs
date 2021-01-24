    public static void ProcessInput(string input)
	{
		int choice = Convert.ToInt32(input);
		switch (choice)
		{
			case 1:
				Console.WriteLine("");
				Console.WriteLine("You have chosen Defult Empire 1");
				break;
			case 2:
				Console.WriteLine("");
				Console.WriteLine("You have chosen Defult Empire 2");
				break;
			case 3:
				Console.WriteLine("");
				Console.WriteLine("You have chosen Defult Empire 3");
				break;
			case 4:
				Console.WriteLine("");
				Console.WriteLine("You have chosen Defult Empire 4");
				break;
			default:
				Console.WriteLine("");
				Console.WriteLine("Input Invalid, Please press the number from the corresponding choices to try again");
				ProcessInput(Console.ReadLine());
				break;
		}
