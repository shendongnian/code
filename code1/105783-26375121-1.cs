		Console.WriteLine("How many numbers do you want to enter?");
		string input2 = Console.ReadLine();
		if (!int.TryParse(input2, out numberTotal2))
		{
			for (int numberTotal2 = 0; numberTotal2 < 1;)
			{
				Console.WriteLine(input2 + " is an invalid number.");
				int.TryParse(Console.ReadLine(), out numberTotal2);
			}
		}
