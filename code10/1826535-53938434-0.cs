	string age1 = Console.ReadLine();
	try
	{
        // Try to parse the read string from user's input as an integer, and
        // set the Age property for the student
		student.Age = int.Parse(age1);
		Console.WriteLine($"Age: {student.Age} ");
	}
	catch (ArgumentNullException)
	{
		Console.WriteLine("Age was not entered.");
	}
	catch (ArgumentOutOfRangeException)
	{
		if (value < 0 || value > 100)
			Console.WriteLine("Please enter a valid age!");
	}
