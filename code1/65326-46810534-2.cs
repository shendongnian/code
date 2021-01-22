	int TheAnswer3 = 0;
	try {
		TheAnswer3 = Int32.Parse("42");
	}
	catch (FormatException) {
		Console.WriteLine("String not in the correct format for an Integer");
	}
	catch (ArgumentNullException) {
		Console.WriteLine("String is null");
	}
	catch (OverflowException) {
		Console.WriteLine("String represents a number less than"
		                  + "MinValue or greater than MaxValue");
	}
